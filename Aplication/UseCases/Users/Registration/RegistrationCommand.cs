using MediatR;

namespace Aplication.UseCases.Users.Registration
{
    public record RegistrationCommand : IRequest<Guid>
    {
        public string FirstName;
        public string SecondName;
        public string ThirdName;
        public string Email;
        public string Password;
        
        public RegistrationCommand(string FirstName, string SecondName, string ThirdName, string Email, string Password)
        { 
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.Email = Email;
            this.Password = Password;
        }
    }
}
