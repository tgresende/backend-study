using System.Collections.Generic;
using System.Threading.Tasks;

using Domain.entities;

namespace Domain.interfaces
{
    public interface ISubjectRepository
    {
        public Task<List<Subject>> GetSubjects(int projectId);
        public Task AddSubject(Subject subject);

    }
}