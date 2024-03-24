using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DataBaseModels
{
    [Table("tbl_event")]
    public class EventDbModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Plan { get; set; }
        public string OrganizerFirstName { get; set; }
        public string OrganizerSecondName { get; set; }
        public string SpickerFirstName { get; set; }
        public string SpickerSecondName { get; set; }
        public DateTime Time { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Category { get; set; }
        public int MaxParticipants { get; set; }
        public int FreePlaces { get; set; }

        public List<ImageDbModel>? Images { get; set; } = new();
        public List<UserDbModel>? Users { get; set; } = new();
    }
}
