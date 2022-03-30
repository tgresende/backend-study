using System.Threading.Tasks;
using Domain.entities;
using Domain.interfaces;

namespace Apllication.services.project
{
    public class ProjectService : IProjectService
    {

        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Project> GetProject(int projectId) =>
            await _projectRepository.GetProject(projectId);

         public async Task<Project> GetRequiredProject(int projectId)
         {
            var project = await _projectRepository.GetProject(projectId);
            if (project == null)
            {
                var message = ProjectNotFoundException(projectId);
                throw new exceptions.project.ProjectNotFoundException(message);
            }

            return project;
         }


         private string ProjectNotFoundException(int projectId) =>
            $"Projeto id: {projectId} não encontrado na base de dados.";
    }
}