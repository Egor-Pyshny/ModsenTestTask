using Domain.Exceptions;
using Domain.Validators;
using FluentValidation.Results;
using System.Text;

namespace Domain.Entities
{
    public class User : IEntity
    {
        public Guid id { get; private set; }
        public string firstName { get; private set; }
        public string secondName { get; private set; }
        public string thirdName { get; private set; }
        public string email { get; private set; }
        public string password { get; private set; }
        public DateTime registrationDate { get; private set; }
    
        private User(Guid id, string firstName, string secondName, string thirdName, string email, string password, DateTime registrationDate)
        {
            this.id = id;
            this.firstName = firstName;
            this.secondName = secondName;
            this.thirdName = thirdName;
            this.email = email;
            this.password = password;
            this.registrationDate = registrationDate;
        }

        public User() { }

        public void Validate()
        {
            UserValidator validator = new UserValidator();
            ValidationResult result = validator.Validate(this);
            if (!result.IsValid)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    stringBuilder.AppendLine(error.ErrorMessage);
                }
                throw new UserCreationException(stringBuilder.ToString());
            }
        }

        public static User Create(string firstName, string secondName, string thirdName, string email, string password, DateTime registrationDate)
        {
            var p = new User(Guid.NewGuid(), firstName, secondName, thirdName, email, password, registrationDate);
            UserValidator validator = new UserValidator();
            ValidationResult result = validator.Validate(p);
            if (!result.IsValid)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    stringBuilder.AppendLine(error.ErrorMessage);
                }
                throw new UserCreationException(stringBuilder.ToString());
            }
            return p;
        }
    }
}
