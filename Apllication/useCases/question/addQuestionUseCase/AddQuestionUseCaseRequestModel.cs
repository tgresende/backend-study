namespace Apllication.useCases.question.addQuestionUseCase
{
    public class AddQuestionUseCaseRequestModel
    {
        public int TopicId { get; set; }
        public int TopicCycleId { get; set; }
        public int CorrectQuestions {get; set;}
        public int DoneQuestions {get; set;}
        public string revisionItem { get; set; }
        public string revisionCycle { get; set; }
        public string readingItem { get; set; }
        public string readingCycle { get; set; }
        public string lawsItem { get; set; }
        public string lawsCycle { get; set; }
    }
}