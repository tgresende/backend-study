using System.Threading.Tasks;
using Domain.interfaces;
using Domain.entities;
using Domain.enums;
using Apllication.services.project;
using Apllication.services.subject;


namespace Apllication.useCases.subject.addSimpleSubjectCycleUseCase
{
    public class AddSimpleSubjectCycleUseCase : IAddSimpleSubjectCycleUseCase
    {
        private readonly IProjectService _projectService;
        private readonly ISubjectService _subjectService;
        private readonly ISubjectCycleRepository _subjectCycleRepository;
        private readonly IUnitOfWork _unitOfWork;

        private const int totalHoursCycle = 14;

        public AddSimpleSubjectCycleUseCase(
            IProjectService projectService,
            ISubjectService subjectService,
            ISubjectCycleRepository subjectCycleRepository,
            IUnitOfWork unitOfWork)
        {
            _projectService = projectService;
            _unitOfWork = unitOfWork;
            _subjectService = subjectService;
            _subjectCycleRepository = subjectCycleRepository;
        }

        public async Task Execute(int projectId)
        {
            var project = await _projectService.GetRequiredProject(projectId);

            var subjects = await _subjectService.GetRequiredProjectSubjects(project.ProjectId);

            var CycleItemMinutesStudy = CalculateCycleItemMinutesStudy(subjects.Count);

            foreach(Subject sub in subjects)
            {
                SubjectCycle subCycle = new SubjectCycle{
                    Status = SubjectCycleEnum.SubjectCycleStatus.Ready,
                    StudyTimeMinutes = CycleItemMinutesStudy,
                    Subject = sub                    
                };

                await _subjectCycleRepository.AddSubjectCycle(subCycle);
            }

            await _unitOfWork.SaveChanges();
        }

        private int CalculateCycleItemMinutesStudy(int subjectsCount) =>
            (totalHoursCycle * 60) / subjectsCount;
    }
}