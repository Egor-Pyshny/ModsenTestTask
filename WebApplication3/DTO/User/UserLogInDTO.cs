using System.ComponentModel.DataAnnotations;

namespace WebApplication3.DTO.User
{
    public class UserLogInDTO
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
