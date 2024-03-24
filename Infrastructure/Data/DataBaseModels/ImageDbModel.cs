using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DataBaseModels
{
    [Table("tbl_images")]
    public class ImageDbModel
    {
        public Guid Id { get; set; }
        public string Path { get; set; }

        public Guid EventId { get; set; }
        public EventDbModel Event { get; set; }
    }
}
