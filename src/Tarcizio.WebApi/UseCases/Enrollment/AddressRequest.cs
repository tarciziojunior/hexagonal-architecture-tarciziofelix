using System;
using Tarcizio.Domain.Enrollment;

namespace Tarcizio.WebApi.UseCases.Enrollment
{
    public sealed class AddressRequest
    {
        public String ZipCode { get; set; }
        public Category Category { get; set; }
    }
}
