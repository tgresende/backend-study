namespace Apllication.useCases.topic.addTopicUseCase
{
    public class AddTopicUseCaseResponseModel
    {
        public int TopicId { get; set; }
        public string Name { get; set; }
        public string Annotations { get; set; }
        public int SubjectId { get; set; }
    }
}