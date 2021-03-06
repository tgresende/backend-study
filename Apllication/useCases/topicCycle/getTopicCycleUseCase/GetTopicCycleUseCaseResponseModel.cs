using Domain.enums;
namespace Apllication.useCases.topicCycle.getTopicCycleUseCase
{
    public class GetTopicCycleUseCaseResponseModel
    {
        public int topicCycleId { get; set; }
        public TopicCycleEnum.TopicCycleEnumScore Score { get; set; }
        public string TopicName { get; set; }
        public int topicId { get; set; }
        public TopicCycleEnum.Action Action { get; set; }

    }
}