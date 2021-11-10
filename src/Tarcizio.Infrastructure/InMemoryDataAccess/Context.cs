using System.Collections.ObjectModel;
using Tarcizio.Domain.Enrollment;

namespace Tarcizio.Infrastructure.InMemoryDataAccess
{
    public class Context
    {
        public Collection<User> Users { get; set; }

        public Context()
        {
            Users = new Collection<User>();
        }
    }
}
