namespace Tarcizio.Infrastructure.InMemoryDataAccess
{
    using System.Collections.ObjectModel;
    using Tarcizio.Domain.Users;

    public class Context
    {
        public Collection<User> Users { get; set; }

        public Context()
        {
            Users = new Collection<User>();
        }
    }
}
