using Domain.Exceptions;
using Domain.Validators;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Address
    { 
        public string country { get; private set; }
        public string city { get; private set; }
        public string street { get; private set; }

        private Address(string counrty, string city, string street)
        {
            this.country = counrty;
            this.city = city;
            this.street = street;
        }

        public Address() { }

        public void Validate()
        {
            AddressValidator validator = new AddressValidator();
            ValidationResult result = validator.Validate(this);
            if (!result.IsValid)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    stringBuilder.AppendLine(error.ErrorMessage);
                }
                throw new AddressCreationException(stringBuilder.ToString());
            }
        }

        public static Address Create(string country, string city, string street)
        {
            var p = new Address(country, city, street);
            AddressValidator validator = new AddressValidator();
            ValidationResult result = validator.Validate(p);
            if (!result.IsValid)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    stringBuilder.AppendLine(error.ErrorMessage);
                }
                throw new AddressCreationException(stringBuilder.ToString());
            }
            return p;
        }
    }
}
