using Domain.entities;

namespace Apllication.services.topic
{
    public static class TopicService
    {
        public static string GetInvalidTopicProperties(Topic topic)
        {
            string message = "";
            if (!topic.IsValidName())
                message += BuildInvalidPropertyMessage("Name", topic.Name);
            
            if (!topic.IsValidPSubjectParent())
                message += BuildInvalidPropertyMessage("Subject", "null");

            return message;

        }

        private static string BuildInvalidPropertyMessage(string propertyName, string propertyValue) 
            => $"Invalid {propertyName}: '{propertyValue}'; ";
    }
}