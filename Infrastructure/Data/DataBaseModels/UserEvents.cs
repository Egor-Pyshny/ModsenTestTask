using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DataBaseModels
{
    [Table("tbl_users_events")]
    public class UserEvents
    {
        public Guid Id { get; set; }

        [ForeignKey("User")]
        public Guid EventId { get; set; }
        public EventDbModel? Event { get; set; }

        [ForeignKey("Event")]
        public Guid UserId { get; set; }
        public UserDbModel? User { get; set; }
    }
}
