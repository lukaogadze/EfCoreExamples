using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreExample.Domain
{
    public class Person : Entity<Guid>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }



        private string City { get;  set; }
        private string Street { get;  set; }
        private string ApartamentNumber { get; set; }

        public Address Address
        {
            get => new Address(City, Street, ApartamentNumber);
            private set
            {
                City = value.City;
                Street = value.Street;
                ApartamentNumber = value.ApartamentNumber;
            }
        }


        private Person() : base(Guid.NewGuid())
        {

        }

        public void Update(Address address)
        {
            Address = address;
        }

        public Person(string firstName, string lastName, Address address) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }
    }
}
