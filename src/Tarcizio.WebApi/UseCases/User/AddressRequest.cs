namespace Tarcizio.WebApi.UseCases.User
{
    using System;
    using Tarcizio.Domain.Users;
    public sealed class AddressRequest
    {
        public String ZipCode { get; set; }
        public Category Category { get; set; }
    }
}
