using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apllication.useCases.topic.getSubjectTopicsUseCase
{
    public interface IGetSubjectTopicsUseCase
    {
        public Task<List<GetSubjectTopicsUseCaseResponseModel>> Execute(int subjectId) ;
    }
}