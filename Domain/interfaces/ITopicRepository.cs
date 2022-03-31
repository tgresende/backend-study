using System.Collections.Generic;
using System.Threading.Tasks;

using Domain.entities;

namespace Domain.interfaces
{
    public interface ITopicRepository
    {
        public Task AddTopic(Topic topic);

        public Task<List<Topic>> GetTopics(int subjectId);

    }
}