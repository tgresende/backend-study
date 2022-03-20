using System.Threading.Tasks;
namespace Domain.interfaces
{
    public interface IUnitOfWork
    {
         Task SaveChanges();
    }
}