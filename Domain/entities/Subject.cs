using System.Collections.Generic;
namespace Domain.entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public string Annotations { get; set; }
        public Project Project { get; set; }
        public List<Topic> Topics { get; set; }


        public bool IsValid() => IsValidName() && IsValidWeight() && IsValidProjectParent();
        public bool IsValidName() => Name.Trim().Length > 0;
        public bool IsValidWeight() => Weight > 0;
        public bool IsValidProjectParent() => Project != null;

    }
}