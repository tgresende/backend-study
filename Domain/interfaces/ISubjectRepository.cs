using System.Collections.Generic;
using System.Threading.Tasks;

using Domain.entities;

namespace Domain.interfaces
{
    public interface ISubjectRepository
    {
        public Task<List<Subject>> GetSubjects(int projectId);
        public Task AddSubject(Subject subject);
        public Task<Subject> GetSubject(int subjectId);
        public Task<List<Topic>> GetSubjectTopics(int subjectId);

    }
}