using System.Threading.Tasks;
using Domain.interfaces;
using Domain.entities;
using Infrasctructure.context;

namespace Infrasctructure.repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private Context _context;

        public ProjectRepository(Context context)
        {
            _context = context;
        }
        public async Task<Project> GetProject(int projectId) => await _context.Projects.FindAsync(projectId);
    }
}