using System.Collections.Generic;
namespace Domain.entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }

        public List<Subject> Subjects {get;set;}

    }
}