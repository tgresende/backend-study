using Domain.entities;
using Domain.enums;

namespace Domain.dtos.topic
{
    public class TopicScoreInfoDTO
    {
        public Topic topic { get; set; }
        public int TotalDoneQuestions { get; set; }
        public int TotalCorrectQuestions { get; set; }
        public int Media { get; set; }
        public TopicCycleEnum.TopicCycleEnumScore Score { get; set; }
    }
}