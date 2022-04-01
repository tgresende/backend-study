using System.Threading.Tasks;
using Domain.interfaces;
using Domain.entities;
using Infrasctructure.context;

namespace Infrasctructure.repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private Context _context;

        public QuestionRepository(Context context)
        {
            _context = context;
        }

        public async Task AddQuestion(Question question)
        {
            await _context.Questions.AddAsync(question);
        }

    }
}