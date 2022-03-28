using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.interfaces;
using Domain.entities;
using Infrasctructure.context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrasctructure.repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private Context _context;

        public SubjectRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<Subject>> GetSubjects(int projectId) => 
           await _context.Subjects.Where(sub=> sub.Project.ProjectId == projectId).ToListAsync();

        public async Task AddSubject(Subject subject)
        {
            await _context.Subjects.AddAsync(subject);
        }

        public async Task<Subject> GetSubject(int subjectId) => 
            await _context.Subjects.FindAsync(subjectId);

        public async Task<List<Topic>> GetSubjectTopics(int subjectId)
        {
            var subject = await _context.Subjects
            .Where(sub => sub.SubjectId == subjectId)
            .Include(sub => sub.Topics)
            .FirstOrDefaultAsync();

            if (subject != null)
                return subject.Topics;

            return new List<Topic>();
        }            
    }
}