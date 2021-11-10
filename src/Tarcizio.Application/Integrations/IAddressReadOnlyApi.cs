using System;
using System.Threading.Tasks;
using Tarcizio.Domain.Enrollment;

namespace Tarcizio.Application.Integrations
{
    public interface IAddressReadOnlyApi
    {
        Task<Address> Get(String zipCode, Category category);
    }
}
