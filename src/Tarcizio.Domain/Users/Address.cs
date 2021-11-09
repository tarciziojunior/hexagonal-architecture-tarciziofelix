using Newtonsoft.Json;
using System;

namespace Tarcizio.Domain.Users
{
    public class Address
    {
        [JsonProperty("cep")]
        public String ZipCode { get; set; }
        public Category Category { get; set; }
        [JsonProperty("logradouro")]
        public String Street { get; set; }
        [JsonProperty("complemento")]
        public String Complement { get; set; }
        [JsonProperty("bairro")]
        public String Neighborhood { get; set; }
        [JsonProperty("localidade")]
        public String Locality { get; set; }
        [JsonProperty("uf")]
        public String State { get; set; }
        public String Ibge { get; set; }
        public String Gia { get; set; }
        public String Ddd { get; set; }
        public String Siafi { get; set; }
    }
}
