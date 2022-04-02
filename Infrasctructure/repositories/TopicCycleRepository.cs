using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.interfaces;
using Domain.entities;
using Infrasctructure.context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrasctructure.repositories
{
    public class TopicCycleRepository : ITopicCycleRepository
    {
        private Context _context;

        public TopicCycleRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<TopicCycle>> GetTopicCycleBySubjectAndStatus(int subjectId, TopicCycleEnum.TopicCycleEnumStatus status) => 
           await _context.TopicCycles
                .Include(cycle => cycle.Topic)
                .Where(cycle=> cycle.Topic.Subject.SubjectId == subjectId 
                    && cycle.Status == status)
                .ToListAsync();

        public async Task AddTopicCycle(TopicCycle topicCycle)
        {
            await _context.TopicCycles.AddAsync(topicCycle);
        }

        public async Task<TopicCycle> GetTopicCycle(int topicCycleId) =>
           await _context.TopicCycles.FindAsync(topicCycleId);

    }
}