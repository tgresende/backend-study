using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.entities;
namespace Apllication.useCases.subject.getSubjectCycleUseCase
{
    public interface IGetSubjectCycleUseCase
    {
        public Task<List<SubjectCycle>> Execute(int projectId);
    }
}