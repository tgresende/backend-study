using System;
using System.Threading.Tasks;
using Domain.interfaces;
using Domain.entities;


namespace Apllication.exceptions.topic
{
    public class TopicsSubjectNotFoundException : Exception
    {
        public TopicsSubjectNotFoundException() { }
        public TopicsSubjectNotFoundException(string message) : base(message) { }
        public TopicsSubjectNotFoundException(string message, Exception innerException) : base(message, innerException)
        { }

    }
}