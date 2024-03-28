using System.ComponentModel.DataAnnotations;

namespace WebApplication3.DTO.User
{
    public class UserAddDTO
    {
        [Required]
        public string FirstName {  get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public string ThirdName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
