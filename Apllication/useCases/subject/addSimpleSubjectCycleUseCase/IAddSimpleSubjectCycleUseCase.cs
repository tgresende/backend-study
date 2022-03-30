using System.Threading.Tasks;
using Domain.entities;
namespace Apllication.useCases.subject.addSimpleSubjectCycleUseCase
{
    public interface IAddSimpleSubjectCycleUseCase
    {
        public Task Execute(int projectId) ;
    }
}