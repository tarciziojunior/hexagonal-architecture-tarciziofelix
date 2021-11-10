namespace Tarcizio.WebApi.UseCases.Enrollment
{
    using System;
    using System.Collections.Generic;

    public sealed class UserRequest
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public DateTime? Birth { get; set; }
        public String Phone { get; set; }
        public List<AddressRequest> addresses { get; set; }
    }
}
