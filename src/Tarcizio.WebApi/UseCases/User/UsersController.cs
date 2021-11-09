namespace Tarcizio.WebApi.UseCases.User
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Tarcizio.Application.Commands.Enrollment;
    using Tarcizio.Domain.Users;

    [Route("api/[controller]")]
    public sealed class UsersController : Controller
    {
        private readonly IUserUseCase userUseCase;
        private readonly IMapper mapper;

        public UsersController(IUserUseCase userUseCase, IMapper mapper)
        {
            this.userUseCase = userUseCase;
            this.mapper = mapper;
        }


        /// <summary>
        /// Register a new User
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserRequest request)
        {
            User user = await userUseCase.Add(mapper.Map<User>(request));
            return new ObjectResult(mapper.Map<UserResponse>(user));
        }

        /// <summary>
        /// Update User
        /// </summary>
        [HttpPut("{id}", Name = "PutUser")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UserRequest request)
        {
            User user = await userUseCase.Update(id, mapper.Map<User>(request));
            return new ObjectResult(mapper.Map<UserResponse>(user));
        }

        /// <summary>
        /// Get user for id
        /// </summary>
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> Get(Guid id)
        {
            IList<UserResponse> users = new List<UserResponse>
            {
                mapper.Map<UserResponse>(await this.userUseCase.Get(id))
            };
            return new ObjectResult(users);
        }

        /// <summary>
        /// Get user addresses
        /// </summary>
        [HttpGet("{id}/addresses", Name = "GetAddresses")]
        public async Task<IActionResult> GetAddress(Guid id)
        {
            return new ObjectResult(mapper.Map<UserResponse>(await this.userUseCase.Get(id)).Addresses);
        }

        /// <summary>
        /// Get user for name
        /// </summary>
        [HttpGet(Name = "GetUserForName")]
        public async Task<IActionResult> Get([FromQuery(Name = "name")] String name)
        {
            IList<UserResponse> users = new List<UserResponse>
            {
                mapper.Map<UserResponse>(await this.userUseCase.Get(name))
            };
            return new ObjectResult(users);
        }

        /// <summary>
        /// Get user for id
        /// </summary>
        [HttpDelete("{id}", Name = "DeleteUser")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.userUseCase.Delete(id);
            return Ok();
        }
    }
}