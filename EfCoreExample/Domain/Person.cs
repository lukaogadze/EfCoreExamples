﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreExample.Domain
{
    public class Person : Entity<Guid>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }



        private string _city;
        private string _street;
        private string _apartamentNumber;

        public Address Address
        {
            get => new Address(_city, _street, _apartamentNumber);
            private set
            {
                _city = value.City;
                _street = value.Street;
                _apartamentNumber = value.ApartamentNumber;
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
