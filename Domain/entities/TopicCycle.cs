namespace Domain.entities
{
    public class TopicCycle
    {
        public int TopicCycleId { get; set; }
        public TopicCycleEnum.TopicCycleEnumStatus Status { get; set; }
        public Topic Topic {get;set;}
        public TopicCycleEnum.TopicCycleEnumScore Score {get;set;}
    }
}