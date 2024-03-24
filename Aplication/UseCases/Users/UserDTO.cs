namespace Aplication.UseCases.Users
{
    public class UserDTO
    {
        public Guid id { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string thirdName { get; set; }
        public string email { get; set; }
        public DateTime registrationDate { get; set; }
    }
}
