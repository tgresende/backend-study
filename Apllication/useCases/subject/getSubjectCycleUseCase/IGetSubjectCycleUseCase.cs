using System.Collections.Generic;
using System.Threading.Tasks;
namespace Apllication.useCases.subject.getSubjectCycleUseCase
{
    public interface IGetSubjectCycleUseCase
    {
        public Task<List<GetSubjectCycleUseCaseResponseModel>> Execute(int projectId);
    }
}