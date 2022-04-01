namespace Domain.entities
{
    public class Question
    {
        public int QuestionId { get; set; }
        public Topic Topic {get;set;}
        public int CorrectQuestions {get; set;}
        public int DoneQuestions {get; set;}
        public long Date {get; set;} //in timestamp

        public bool IsValid() => CorrectAndDoneQuestionsValidate();

        private bool CorrectAndDoneQuestionsValidate() => CorrectQuestions <= DoneQuestions;
    }
}