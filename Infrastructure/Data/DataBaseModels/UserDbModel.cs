using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DataBaseModels
{
    [Table("tbl_user")]
    public class UserDbModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }

        public List<EventDbModel>? Events { get; set; } = new();
    }
}
