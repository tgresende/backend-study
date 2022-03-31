using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.interfaces;
using Domain.entities;
using Infrasctructure.context;
using Microsoft.EntityFrameworkCore;
using System.Linq;


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

        public async Task<List<Topic>> GetTopics(int subjectId)
        {
            return await _context.Topics
                .Where(topic => topic.Subject.SubjectId == subjectId)
                .ToListAsync();;
        }
    }
}