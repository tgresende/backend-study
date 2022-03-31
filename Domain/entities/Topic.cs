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
        public bool IsValid() => IsValidName() && IsValidPSubjectParent();
        public bool IsValidName() => Name.Trim().Length > 0;
        public bool IsValidPSubjectParent() => Subject != null;

    }
}