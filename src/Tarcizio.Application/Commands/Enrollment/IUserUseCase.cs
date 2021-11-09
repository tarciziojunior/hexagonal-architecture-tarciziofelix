using System;
using System.Threading.Tasks;
using Tarcizio.Domain.Users;

namespace Tarcizio.Application.Commands.Enrollment
{
    public interface IUserUseCase
    {
        Task<User> Add(User user);
        Task<User> Get(Guid guid);
        Task<User> Get(string name);
        Task Delete(Guid id);
        Task<User> Update(Guid id, User user);
    }
}
