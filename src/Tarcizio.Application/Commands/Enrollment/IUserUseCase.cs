using System;
using System.Threading.Tasks;
using Tarcizio.Domain.Enrollment;

namespace Tarcizio.Application.Commands.Enrollment
{
    public interface IUserUseCase
    {
        Task<User> Add(User user);
        Task<User> Get(Guid guid);
        Task<User> Get(string name);
        Task Delete(Guid id);
        Task Update(Guid id, User user);
    }
}
