using System;
using System.Linq;
using System.Threading.Tasks;
using Tarcizio.Application.Repositories;
using Tarcizio.Domain.Users;

namespace Tarcizio.Infrastructure.InMemoryDataAccess.Repositories
{
    public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            _context.Users.Add(user);
            await Task.CompletedTask;
        }

        public async Task<User> Get(Guid id)
        {
            User user = _context.Users
                .Where(e => e.Id == id && e.Status == Status.Active)
                .SingleOrDefault();

            return await Task.FromResult<User>(user);
        }

        public async Task<User> Get(string name)
        {
            User user = _context.Users
               .Where(e => e.Name == name && e.Status == Status.Active)
               .SingleOrDefault();
            return await Task.FromResult<User>(user);
        }

        public async Task Update(User user)
        {
            User userOld = _context.Users
                .Where(e => e.Id == user.Id && e.Status == Status.Active)
                .SingleOrDefault();
            userOld = user;
            await Task.CompletedTask;
        }
    }
}
