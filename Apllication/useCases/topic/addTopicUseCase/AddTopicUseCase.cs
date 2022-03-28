using System.Threading.Tasks;
using Domain.interfaces;
using Domain.entities;

namespace Apllication.useCases.topic.addTopicUseCase
{
    public class AddTopicUseCase : IAddTopicUseCase
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ITopicRepository _topicRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddTopicUseCase(ISubjectRepository subjectRepository, ITopicRepository topicRepository,
        IUnitOfWork unitOfWork)
        {
            _subjectRepository = subjectRepository;
            _topicRepository = topicRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddTopicUseCaseResponseModel> Execute(AddTopicUseCaseRequestModel requestModel)
        {
            var subject = await _subjectRepository.GetSubject(requestModel.SubjectId);

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
                throw new exceptions.InvalidSubjectException(SubjectService.GetInvalidSubjectProperties(sub));
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