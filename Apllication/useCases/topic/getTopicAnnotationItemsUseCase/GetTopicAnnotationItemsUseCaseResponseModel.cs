namespace Apllication.useCases.topic.getTopicAnnotationItemsUseCase
{
    public class GetTopicAnnotationItemsUseCaseResponseModel
    {
        public int TopicId { get; set; }
        public string Name { get; set; }
        public string Annotations { get; set; }
        public int SubjectId { get; set; }
        public string revisionItem { get; set; }
        public string revisionCycle { get; set; }
        public string readingItem { get; set; }
        public string readingCycle { get; set; }
        public string lawsItem { get; set; }
        public string lawsCycle { get; set; }
    }
}