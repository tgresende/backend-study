using System.Threading.Tasks;
using Domain.interfaces;
using Domain.entities;
using Apllication.services.subject;

namespace Apllication.useCases.subject.addSubjectUseCase
{
    public class AddSubjectUseCase : IAddSubjectUseCase
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IProjectRepository _projectRepository;

        private readonly ISubjectService _subjectService;

        private readonly IUnitOfWork _unitOfWork;

        public AddSubjectUseCase(ISubjectRepository subjectRepository, 
        IProjectRepository projectRepository,
        ISubjectService subjectService,
        IUnitOfWork unitOfWork)
        {
            _subjectRepository = subjectRepository;
            _projectRepository = projectRepository;
            _subjectService = subjectService;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddSubjectUseCaseResponseModel> Execute(AddSubjectUseCaseRequestModel requestModel)
        {
            var project = await _projectRepository.GetProject(requestModel.ProjectId);

            var subject = new Subject(){
                Annotations = requestModel.Annotations,
                Name = requestModel.Name,
                Weight = requestModel.Weight,
                Project = project
            };

            ValidateSubject(subject);

            await _subjectRepository.AddSubject(subject);

            await _unitOfWork.SaveChanges();

            return ParseToResponseModel(subject);
        }

        private void ValidateSubject(Subject sub)
        {
            if (!sub.IsValid())
            {
                throw new exceptions.InvalidSubjectException(_subjectService.GetInvalidSubjectProperties(sub));
            }
        }

        private AddSubjectUseCaseResponseModel ParseToResponseModel(Subject sub) =>
            new AddSubjectUseCaseResponseModel(){
                Annotations = sub.Annotations,
                Name = sub.Name,
                ProjectId = sub.Project.ProjectId,
                SubjectId = sub.SubjectId,
                Weight = sub.Weight
            };

    }
}