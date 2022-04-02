using System;


namespace Apllication.exceptions.topicCycle
{
    public class TopicCycleNotFoundException : Exception
    {
        public TopicCycleNotFoundException() { }
        public TopicCycleNotFoundException(string message) : base(message) { }
        public TopicCycleNotFoundException(string message, Exception innerException) : base(message, innerException)
        { }

    }
}