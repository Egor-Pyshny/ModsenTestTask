namespace WebApplication3.DTO.Catalog
{
    public class EventCatalogDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string OrganizerFirstName { get; set; }
        public string OrganizerSecondName { get; set; }
        public string MainImage { get; set; }
        public int FreePlaces { get; set; }
    }
}
