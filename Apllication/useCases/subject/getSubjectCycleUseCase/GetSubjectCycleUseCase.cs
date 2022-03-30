using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.interfaces;
using Domain.entities;
using Apllication.services.project;
using Apllication.services.subject;


namespace Apllication.useCases.subject.getSubjectCycleUseCase
{
    public class GetSubjectCycleUseCase : IGetSubjectCycleUseCase
    {
        private readonly ISubjectCycleRepository _subjectCycleRepository;
        public GetSubjectCycleUseCase(
            ISubjectCycleRepository subjectCycleRepository
        )
        {
            _subjectCycleRepository = subjectCycleRepository;
        }

        public async Task<List<GetSubjectCycleUseCaseResponseModel>> Execute(int projectId)
        {
            var subjectsCycle = await _subjectCycleRepository.GetSubjectCyclesByStatus(projectId, SubjectCycleEnum.SubjectCycleStatus.Ready);

            return ParseListToResponseModel(subjectsCycle);
        }

        private List<GetSubjectCycleUseCaseResponseModel> ParseListToResponseModel(List<SubjectCycle> subjectsCycle)
        {
            List<GetSubjectCycleUseCaseResponseModel> result = new();
            foreach(SubjectCycle cycleItem in subjectsCycle)
            {
                result.Add(ParseEntityToResponseModel(cycleItem));
            }
            return result;
        }

        private GetSubjectCycleUseCaseResponseModel ParseEntityToResponseModel(SubjectCycle subjectCycle) =>
        new GetSubjectCycleUseCaseResponseModel{
            status = subjectCycle.Status,
            StudyTimeMinutes = subjectCycle.StudyTimeMinutes,
            subjectCycleId = subjectCycle.SubjectCycleId,
            SubjectId = subjectCycle.Subject.SubjectId,
            SubjectName = subjectCycle.Subject.Name,
        };

    }
}