using Domain.entities;

namespace Apllication.services.subject
{
    public static class SubjectService
    {
        public static string GetInvalidSubjectProperties(Subject subject)
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
    }
}