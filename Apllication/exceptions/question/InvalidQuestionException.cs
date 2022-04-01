using System;
using System.Threading.Tasks;
using Domain.interfaces;
using Domain.entities;


namespace Apllication.exceptions.question
{
    public class InvalidQuestionException : Exception
    {
        public InvalidQuestionException() { }
        public InvalidQuestionException(string message) : base(message) { }
        public InvalidQuestionException(string message, Exception innerException) : base(message, innerException)
        { }

    }
}