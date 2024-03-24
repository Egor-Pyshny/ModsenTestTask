namespace Aplication.UseCases.Events
{
    public class EventDTO
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string plan { get; set; }
        public string spickerFirstName { get; set; }
        public string spickerSecondName { get; set; }
        public string organizerFirstName { get; set; }
        public string organizerSecondName { get; set; }
        public DateTime time { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string category { get; set; }
        public int maxParticipants { get; set; }
        public int freePlaces { get; set; }
        public List<string> images { get; set; } = new();
    }
}
