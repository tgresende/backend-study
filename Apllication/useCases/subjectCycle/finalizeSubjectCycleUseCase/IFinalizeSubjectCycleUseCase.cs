using System.Threading.Tasks;
namespace Apllication.useCases.subjectCycle.finalizeSubjectCycleUseCase
{
    public interface IFinalizeSubjectCycleUseCase
    {
        public Task Execute(int subjectCycleId) ;
    }
}