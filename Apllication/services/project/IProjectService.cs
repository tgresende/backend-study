using System.Threading.Tasks;
using Domain.entities;

namespace Apllication.services.project
{
    public interface IProjectService
    {
        Task<Project> GetProject(int projectId);
        Task<Project> GetRequiredProject(int projectId);
    }
}