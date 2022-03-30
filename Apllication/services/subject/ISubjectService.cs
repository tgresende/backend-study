using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.entities;

namespace Apllication.services.subject
{
    public interface ISubjectService
    {
        string GetInvalidSubjectProperties(Subject subject);
        Task<List<Subject>> GetRequiredProjectSubjects(int projectId);
    }
}