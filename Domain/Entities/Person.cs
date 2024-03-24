using Domain.Exceptions;
using Domain.Validators;
using FluentValidation.Results;
using System.Text;

namespace Domain.Entities
{
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        private Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Person() { }

        public void Validate()
        {
            PersonValidator validator = new PersonValidator();
            ValidationResult result = validator.Validate(this);
            if (!result.IsValid)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    stringBuilder.AppendLine(error.ErrorMessage);
                }
                throw new PersonCreationException(stringBuilder.ToString());
            }
        }

        public static Person Create(string firstName, string lastName)
        {
            var p = new Person(firstName, lastName);
            PersonValidator validator = new PersonValidator();
            ValidationResult result = validator.Validate(p);
            if (!result.IsValid)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    stringBuilder.AppendLine(error.ErrorMessage);
                }
                throw new PersonCreationException(stringBuilder.ToString());
            }
            return p;
        }
    }
}
