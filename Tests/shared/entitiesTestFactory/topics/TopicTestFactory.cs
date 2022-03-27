using Domain.entities;

namespace Tests.shared.entitiesTestFactory.subjects
{
    public class TopicTestFactory
    {
        public Topic GetCompleteTopic()
        => new Topic(){
                TopicId = 1,
                Name = "topic name",
                Annotations = "topic annotatios",
                Subject = new Subject()
                {
                    SubjectId = 1,
                }
            };

    }
}