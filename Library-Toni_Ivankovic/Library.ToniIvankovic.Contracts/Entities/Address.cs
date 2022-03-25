namespace Library.ToniIvankovic.Contracts.Entities
{
    public class Address
    {
        public Address(int id, string street, string city, string country)
        {
            Id = id;
            Street = street;
            City = city;
            Country = country;
        }

        public int Id { get; set; }

        public Person Person { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
