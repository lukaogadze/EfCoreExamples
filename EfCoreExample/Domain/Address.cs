namespace EfCoreExample.Domain
{
    public class Address
    {
        public string City { get; private set; }
        public string Street { get; private set; }
        public string ApartamentNumber { get; private set; }

        private Address()
        {

        }

        public Address(string city, string street, string apartamentNumber) : this()
        {
            City = city;
            Street = street;
            ApartamentNumber = apartamentNumber;
        }
    }
}