using System;


namespace Apllication.exceptions.topic
{
    public class TopicNotFoundException : Exception
    {
        public TopicNotFoundException() { }
        public TopicNotFoundException(string message) : base(message) { }
        public TopicNotFoundException(string message, Exception innerException) : base(message, innerException)
        { }

    }
}