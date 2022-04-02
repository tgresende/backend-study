using System.Threading.Tasks;
namespace Apllication.useCases.topicCycle.addOptimizedTopicCycleUseCase
{
    public interface IAddOptimizedTopicCycleUseCase
    {
        public Task Execute(int subjectId);
    }
}