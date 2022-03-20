using System.Threading.Tasks;
using Domain.entities;

namespace Domain.interfaces
{
    public interface IProjectRepository
    {
        public Task<Project> GetProject(int projectId);

    }
}