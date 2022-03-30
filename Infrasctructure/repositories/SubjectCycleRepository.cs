using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.interfaces;
using Domain.entities;
using Infrasctructure.context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrasctructure.repositories
{
    public class SubjectCycleRepository : ISubjectCycleRepository
    {
        private Context _context;

        public SubjectCycleRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<SubjectCycle>> GetSubjectCyclesByStatus(int projectId, SubjectCycleEnum.SubjectCycleStatus status) => 
           await _context.SubjectCycles
                .Where(sub=> sub.Subject.Project.ProjectId == projectId 
                    && sub.Status == status)
                .ToListAsync();

        public async Task AddSubjectCycle(SubjectCycle subjectCycle)
        {
            await _context.SubjectCycles.AddAsync(subjectCycle);
        }

    }
}