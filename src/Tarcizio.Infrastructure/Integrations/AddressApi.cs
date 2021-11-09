﻿using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Tarcizio.Application.Integrations;
using Tarcizio.Domain.Users;

namespace Tarcizio.Infrastructure.Integrations
{
    public class AddressApi : IAddressReadOnlyApi
    {
        private readonly HttpClient httpClient;
        private readonly String viaCep;

        public AddressApi(HttpClient httpClient, String viaCep)
        {
            this.httpClient = httpClient;
            this.viaCep = viaCep;
        }

        public async Task<Address> Get(string zipCode, Category category)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, String.Format(viaCep + "{0}/json/", zipCode));
            request.Headers.Add("Accept", "application/json");

            var response = await httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new AddressNotFoundException(String.Format("Address {0} not fountd", zipCode));
            }
            String responseStream = await response.Content.ReadAsStringAsync();
            Address address = JsonConvert.DeserializeObject<Address>(responseStream);
            address.Category = category;
            return address;


        }
    }
}
