using System.Collections.Generic;
using System.Threading.Tasks;

using Domain.entities;

namespace Domain.interfaces
{
    public interface ITopicCycleRepository
    {
        public Task<List<TopicCycle>> GetTopicCycleBySubjectAndStatus(int subjectId, TopicCycleEnum.TopicCycleEnumStatus status);
        public Task AddTopicCycle(TopicCycle topicCycle);
        public Task<TopicCycle> GetTopicCycle(int topicCycle);


    }
}