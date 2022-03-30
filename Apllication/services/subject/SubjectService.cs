using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.entities;
using Domain.interfaces;

namespace Apllication.services.subject
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public async Task<List<Subject>> GetRequiredProjectSubjects(int projectId)
        {
            var subjects = await _subjectRepository.GetSubjects(projectId);
            
            if (subjects.Count == 0)
                throw new exceptions.subject.SubjectsProjectNotFoundException(MessageSubjectsNotFound(projectId));
            return subjects;
        }

        public string GetInvalidSubjectProperties(Subject subject)
        {
            string message = "";
            if (!subject.IsValidName())
                message += BuildInvalidPropertyMessage("Name", subject.Name);
            
            if (!subject.IsValidWeight())
                message += BuildInvalidPropertyMessage("Weight", subject.Weight.ToString());

            if (!subject.IsValidProjectParent())
                message += BuildInvalidPropertyMessage("Project", "null");

            return message;

        }

        private static string BuildInvalidPropertyMessage(string propertyName, string propertyValue) 
            => $"Invalid {propertyName}: '{propertyValue}'; ";

        private static string MessageSubjectsNotFound(int projectId) 
            => $"Não foram encontrados assuntos para o projeto: {projectId}.";
    }
}