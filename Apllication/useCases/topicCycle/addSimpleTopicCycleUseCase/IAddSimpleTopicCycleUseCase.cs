using System.Threading.Tasks;
namespace Apllication.useCases.topicCycle.addSimpleTopicCycleUseCase
{
    public interface IAddSimpleTopicCycleUseCase
    {
        public Task Execute(int subjectId);
    }
}