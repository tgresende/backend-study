using Domain.entities;

namespace Tests.shared.entitiesTestFactory.subjects
{
    public class SubjectTestFactory
    {
        public Subject GetCompleteSubject()
        => new Subject(){
                SubjectId = 1,
                Name = "subject name",
                Weight = 1,
                Annotations = "subject annotatios",
                Project = new Project()
                {
                    ProjectId= 1,
                    Name = "project name"
                }
            };

    }
}