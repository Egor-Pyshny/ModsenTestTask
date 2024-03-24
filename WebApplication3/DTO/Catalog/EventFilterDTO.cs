namespace WebApplication3.DTO.Catalog
{
    public class EventFilterDTO
    {
        public string Country { get; set; } = null;
        public string City { get; set; } = null;
        public string Organizer { get; set; } = null;
        public DateOnly? Date { get; set; } = null;
    }
}
