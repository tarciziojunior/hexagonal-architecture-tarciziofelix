using System;
using System.Collections.Generic;

namespace Tarcizio.WebApi.UseCases.Enrollment
{
    public sealed class UserResponse
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public DateTime? Birth { get; set; }
        public String Phone { get; set; }
        public List<AddressResponse> Addresses { get; set; }
    }
}
