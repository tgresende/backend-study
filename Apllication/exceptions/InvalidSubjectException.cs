using System;
using System.Threading.Tasks;
using Domain.interfaces;
using Domain.entities;


namespace Apllication.exceptions
{
    public class InvalidSubjectException : Exception
    {
        public InvalidSubjectException() { }
        public InvalidSubjectException(string message) : base(message) { }
        public InvalidSubjectException(string message, Exception innerException) : base(message, innerException)
        { }

    }
}