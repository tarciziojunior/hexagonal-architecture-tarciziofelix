using System;
using Tarcizio.Domain.Enrollment;

namespace Tarcizio.WebApi.UseCases.Enrollment
{
    public sealed class AddressResponse
    {
        public String ZipCode { get; set; }
        public Category Category { get; set; }
        public String Street { get; set; }
        public String Complement { get; set; }
        public String Neighborhood { get; set; }
        public String Locality { get; set; }
        public String State { get; set; }
        public String Ibge { get; set; }
        public String Gia { get; set; }
        public String Ddd { get; set; }
        public String Siafi { get; set; }
    }
}
