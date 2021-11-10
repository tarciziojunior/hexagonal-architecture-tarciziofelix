using NSubstitute;
using System;
using System.Collections.Generic;
using Tarcizio.Application;
using Tarcizio.Application.Commands.Enrollment;
using Tarcizio.Application.Integrations;
using Tarcizio.Application.Repositories;
using Tarcizio.Domain.Enrollment;
using Xunit;

namespace Tarcizio.UseCases.Tests
{
    public class UserTests
    {
        public IUserReadOnlyRepository userReadOnlyRepository;
        public IUserWriteOnlyRepository userWriteOnlyRepository;
        public IAddressReadOnlyApi addressReadOnlyApi;


        public UserTests()
        {
            userReadOnlyRepository = Substitute.For<IUserReadOnlyRepository>();
            userWriteOnlyRepository = Substitute.For<IUserWriteOnlyRepository>();
            addressReadOnlyApi = Substitute.For<IAddressReadOnlyApi>();

        }

        [Theory]
        [InlineData("Tarcizio", "tarcizio@gmail.com", "(27) 99917-6002")]
        public async void User_Should_Add_User(String name, String email, String phone)
        {
            var userUseCase = new UserUseCase(
                userReadOnlyRepository,
                userWriteOnlyRepository,
                addressReadOnlyApi
            );
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                Phone = phone,
                Addresses = new List<Address>()
            };

            User userResult = await userUseCase.Add(user);

            Assert.Equal(user.Id, userResult.Id);
            Assert.Equal(user.Name, userResult.Name);
            Assert.Equal(user.Email, userResult.Email);
            Assert.Equal(user.Phone, userResult.Phone);
        }

        [Theory]
        [InlineData("Tarcizio", "tarcizio@gmail.com", "(27) 99917-6002")]
        public async void User_Should_Remove_User(String name, String email, String phone)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                Phone = phone,
                Addresses = new List<Address>()
            };

            userReadOnlyRepository
               .Get(user.Id)
               .Returns(user);

            var userUseCase = new UserUseCase(
                userReadOnlyRepository,
                userWriteOnlyRepository,
                addressReadOnlyApi
            );

            await userUseCase.Delete(user.Id);



        }

        [Theory]
        [InlineData("Tarcizio", "tarcizio@gmail.com", "(27) 99917-6002")]
        public async void User_Should_Get_Id_User(String name, String email, String phone)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                Phone = phone,
                Addresses = new List<Address>()
            };

            userReadOnlyRepository
               .Get(user.Id)
               .Returns(user);

            var userUseCase = new UserUseCase(
                userReadOnlyRepository,
                userWriteOnlyRepository,
                addressReadOnlyApi
            );

            var userResult = await userUseCase.Get(user.Id);

            Assert.Equal(user.Id, userResult.Id);
            Assert.Equal(user.Name, userResult.Name);
            Assert.Equal(user.Email, userResult.Email);
            Assert.Equal(user.Phone, userResult.Phone);

            await Assert.ThrowsAsync<UserNotFoundException>(
               () =>
               {
                   return userUseCase.Get(Guid.NewGuid());
               });
        }

        [Theory]
        [InlineData("Tarcizio", "tarcizio@gmail.com", "(27) 99917-6002")]
        public async void User_Should_Get_Name_User(String name, String email, String phone)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                Phone = phone,
                Addresses = new List<Address>()
            };

            userReadOnlyRepository
               .Get(user.Name)
               .Returns(user);

            var userUseCase = new UserUseCase(
                userReadOnlyRepository,
                userWriteOnlyRepository,
                addressReadOnlyApi
            );

            var userResult = await userUseCase.Get(name);

            Assert.Equal(user.Id, userResult.Id);
            Assert.Equal(user.Name, userResult.Name);
            Assert.Equal(user.Email, userResult.Email);
            Assert.Equal(user.Phone, userResult.Phone);

        }
    }
}
