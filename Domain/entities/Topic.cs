using System.Linq;
using System.Collections.Generic;
using Domain.dtos.topic
;
namespace Domain.entities
{
    public class Topic
    {
        public int TopicId { get; set; }
        public string Name { get; set; }
        public string Annotations { get; set; }
        public Subject Subject { get; set; }
        public List<TopicCycle> TopicCycles { get; set; }
        public List<Question> Questions { get; set; }
        public string revisionItem { get; set; }
        public string revisionCycle { get; set; }
        public string readingItem { get; set; }
        public string readingCycle { get; set; }
        public string lawsItem { get; set; }
        public string lawsCycle { get; set; }
                

        public bool IsValid() => IsValidName() && IsValidPSubjectParent();
        public bool IsValidName() => Name.Trim().Length > 0;
        public bool IsValidPSubjectParent() => Subject != null;
        public TopicScoreInfoDTO CalcScore()
        {
            int correctQuestion = 0;
            int doneQuestion = 0;

            foreach(Question question in Questions)
            {
                doneQuestion+=question.DoneQuestions;
                correctQuestion+=question.CorrectQuestions;
            }

            int media = correctQuestion*100/doneQuestion;

            return new TopicScoreInfoDTO{
                Media= media,
                Score = GetScoreAbc(media),
                TotalCorrectQuestions = correctQuestion,
                TotalDoneQuestions = doneQuestion,
                topic = this
            };
        }
           

        private TopicCycleEnum.TopicCycleEnumScore GetScoreAbc(int media)
        {
            if (media < 60)
                return TopicCycleEnum.TopicCycleEnumScore.C;
            
            if (media < 80)
                return TopicCycleEnum.TopicCycleEnumScore.B;

            return TopicCycleEnum.TopicCycleEnumScore.A;
        }


    }
}