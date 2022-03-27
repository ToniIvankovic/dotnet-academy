using System.Text.Json.Serialization;

namespace Library.ToniIvankovic.Contracts.Entities
{
    public class Address
    {
        public int Id { get; set; }

        [JsonIgnore]
        public Person Person { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
