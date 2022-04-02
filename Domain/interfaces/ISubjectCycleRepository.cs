using System.Collections.Generic;
using System.Threading.Tasks;

using Domain.entities;

namespace Domain.interfaces
{
    public interface ISubjectCycleRepository
    {
        public Task<List<SubjectCycle>> GetSubjectCyclesByStatus(int projectId, SubjectCycleEnum.SubjectCycleStatus status);
        public Task AddSubjectCycle(SubjectCycle subjectCycle);
        public Task<SubjectCycle> GetSubjectCycle(int subjectCycleId);
    }
}