using System;
using System.Threading.Tasks;
using Tarcizio.Application.Integrations;
using Tarcizio.Application.Repositories;
using Tarcizio.Domain.Enrollment;

namespace Tarcizio.Application.Commands.Enrollment
{
    public sealed class UserUseCase : IUserUseCase
    {
        private readonly IUserReadOnlyRepository userReadOnlyRepository;
        private readonly IUserWriteOnlyRepository userWriteOnlyRepository;
        private readonly IAddressReadOnlyApi addressReadOnlyApi;

        public UserUseCase(IUserReadOnlyRepository userReadOnlyRepository, IUserWriteOnlyRepository userWriteOnlyRepository, IAddressReadOnlyApi addressReadOnlyApi)
        {
            this.userReadOnlyRepository = userReadOnlyRepository;
            this.userWriteOnlyRepository = userWriteOnlyRepository;
            this.addressReadOnlyApi = addressReadOnlyApi;
        }

        public async Task Delete(Guid id)
        {
            User user = await Get(id);
            user.Inactive();
            await this.userWriteOnlyRepository.Update(user);
        }

        public async Task<User> Add(User user)
        {
            user.Id = Guid.NewGuid();
            user.BusinessRules();
            user.Active();
            for (int i = 0; i < user.GetNumberOfAddresses(); i++)
            {
                user.Addresses[i] = await this.addressReadOnlyApi.Get(user.Addresses[i].ZipCode, user.Addresses[i].Category);
            }
            await this.userWriteOnlyRepository.Add(user);
            return user;
        }

        public async Task<User> Get(Guid guid)
        {
            var user = await userReadOnlyRepository.Get(guid);
            return IsNulUser(user);
        }

        public async Task<User> Get(String name)
        {
            var user = await userReadOnlyRepository.Get(name);
            return IsNulUser(user);
        }

        public async Task Update(Guid id, User user)
        {
            user.BusinessRules();
            User userOld = await Get(id);
            userOld.Name = user.Name;
            userOld.Email = user.Email;
            userOld.Phone = user.Phone;
            for (int i = 0; i < userOld.GetNumberOfAddresses(); i++)
            {
                userOld.Addresses[i] = await this.addressReadOnlyApi.Get(user.Addresses[i].ZipCode, user.Addresses[i].Category);
            }
            await this.userWriteOnlyRepository.Update(userOld);           
        }

        private User IsNulUser(User user)
        {
            if (user == null)
            {
                throw new UserNotFoundException("The user does not exists");
            }
            return user;
        }
    }
}
