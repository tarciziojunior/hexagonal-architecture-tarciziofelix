using System;
using System.Threading.Tasks;
using Tarcizio.Domain.Users;

namespace Tarcizio.Application.Repositories
{
    public interface IUserReadOnlyRepository
    {
        Task<User> Get(Guid id);
        Task<User> Get(string name);
    }
}
