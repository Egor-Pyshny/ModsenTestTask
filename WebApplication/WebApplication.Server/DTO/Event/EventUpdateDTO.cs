using System.ComponentModel.DataAnnotations;

namespace WebApplication3.DTO.Event
{
    public class EventUpdateDTO
    {
        [Required]
        public Guid id { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public string? description { get; set; }
        [Required]
        public string? plan { get; set; }
        [Required]
        public string? spickerFirstName { get; set; }
        [Required]
        public string? spickerSecondName { get; set; }
        [Required]
        public string? organizerFirstName { get; set; }
        [Required]
        public string? organizerSecondName { get; set; }
        [Required]
        public DateTime? time { get; set; } 
        [Required]
        public string? country { get; set; } 
        [Required]
        public string? city { get; set; }
        [Required]
        public string? street { get; set; } 
        [Required]
        public string? category { get; set; }
        [Required]
        public int? maxParticipants { get; set; } 
    }
}
