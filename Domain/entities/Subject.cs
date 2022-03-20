namespace Domain.entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public string Annotations { get; set; }
        public Project Project { get; set; }

        public bool IsValid() => IsValidName() && IsValidWeight() && IsValidProjectParent();
        private bool IsValidName() => Name.Trim().Length > 0;
        private bool IsValidWeight() => Weight > 0;
        private bool IsValidProjectParent() => (Project != null && Project.ProjectId > 0);

    }
}