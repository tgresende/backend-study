using System.Threading.Tasks;
using Domain.interfaces;
using Infrasctructure.context;

namespace Infrasctructure.repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Context _context;

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
            
    }
}