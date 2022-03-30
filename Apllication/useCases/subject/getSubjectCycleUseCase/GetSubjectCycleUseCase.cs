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

        public async Task<List<SubjectCycle>> Execute(int projectId)
        {
            return await _subjectCycleRepository.GetSubjectCyclesByStatus(projectId, SubjectCycleEnum.SubjectCycleStatus.Ready);

        }
    }
}