namespace Apllication.useCases.question.addQuestionUseCase
{
    public class AddQuestionUseCaseRequestModel
    {
        public int TopicId { get; set; }
        public int CorrectQuestions {get; set;}
        public int DoneQuestions {get; set;}
    }
}