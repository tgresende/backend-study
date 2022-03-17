namespace Domain.entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public string Annotations { get; set; }
        public Project Project { get; set; }

    }
}