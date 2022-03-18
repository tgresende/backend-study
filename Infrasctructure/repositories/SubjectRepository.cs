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

        public Task<List<Subject>> GetSubjects(int projectId) => 
            _context.Subjects.Where(sub=> sub.Project.ProjectId == projectId).ToListAsync();
            
    }
}