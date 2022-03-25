namespace Library.ToniIvankovic.Contracts.Entities
{
    public class Address
    {
        public Address(string street, string city, string country)
        {
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
