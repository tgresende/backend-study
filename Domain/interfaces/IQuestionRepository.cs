using System.Threading.Tasks;

using Domain.entities;

namespace Domain.interfaces
{
    public interface IQuestionRepository
    {
        public Task AddQuestion(Question question);
    }
}