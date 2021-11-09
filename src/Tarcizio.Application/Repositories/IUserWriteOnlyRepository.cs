using System.Threading.Tasks;
using Tarcizio.Domain.Users;

namespace Tarcizio.Application.Repositories
{
    public interface IUserWriteOnlyRepository
    {
        Task Add(User user);
        Task Update(User user);
    }
}
