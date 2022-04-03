using Domain.enums;

namespace Apllication.useCases.topic.getSubjectTopicsUseCase
{
    public class GetSubjectTopicsUseCaseResponseModel
    {
        public int TopicId { get; set; }
        public string Name { get; set; }
        public string Annotations { get; set; }
        public int Media { get; set; }
        public TopicCycleEnum.TopicCycleEnumScore Score { get; set; }

    }
}