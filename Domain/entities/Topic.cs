using System.Collections.Generic;
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

    }
}