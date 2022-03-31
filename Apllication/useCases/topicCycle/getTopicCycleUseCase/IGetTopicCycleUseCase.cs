using System.Collections.Generic;
using System.Threading.Tasks;
namespace Apllication.useCases.topicCycle.getTopicCycleUseCase
{
    public interface IGetTopicCycleUseCase
    {
        public Task<List<GetTopicCycleUseCaseResponseModel>> Execute(int subjectId);
    }
}