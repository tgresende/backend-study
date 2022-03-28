using System.Threading.Tasks;
using Domain.interfaces;
using Domain.entities;
using Infrasctructure.context;

namespace Infrasctructure.repositories
{
    public class TopicRepository : ITopicRepository
    {
        private Context _context;

        public TopicRepository(Context context)
        {
            _context = context;
        }

        public async Task AddTopic(Topic topic)
        {
            await _context.Topics.AddAsync(topic);
        }
    }
}