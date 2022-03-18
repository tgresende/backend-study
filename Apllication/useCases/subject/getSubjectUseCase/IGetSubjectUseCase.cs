using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apllication.useCases.subject.getSubjectUseCase
{
    public interface IGetSubjectUseCase
    {
        public Task<List<GetSubjectUseCaseResponseModel>> Execute(int projectId) ;
    }
}