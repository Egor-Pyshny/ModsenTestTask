using MediatR;
using Microsoft.AspNetCore.Http;

namespace Aplication.UseCases.Events.Create
{
    public record CreateEventCommand : IRequest<(Guid, Guid)>
    {
        public string name;
        public string description;
        public string plan;
        public string spickerFirstName;
        public string spickerSecondName;
        public string organizerFirstName;
        public string organizerSecondName;
        public DateTime time;
        public string country;
        public string city;
        public string street;
        public string category;
        public int maxParticipants;
        public IFormFile file;

        public CreateEventCommand() { }

        public CreateEventCommand(string name, string description, string plan, 
            string spickerFirstName, string spickerSecondName, string organizerFirstName, 
            string organizerSecondName, DateTime time, string country, string city,
            string street, string category, int maxParticipants, IFormFile file)
        {
            this.name = name;
            this.description = description;
            this.plan = plan;
            this.spickerFirstName = spickerFirstName;
            this.spickerSecondName = spickerSecondName;
            this.organizerFirstName = organizerFirstName;
            this.organizerSecondName = organizerSecondName;
            this.time = time;
            this.country = country;
            this.city = city;
            this.street = street;
            this.category = category;
            this.maxParticipants = maxParticipants;
            this.file = file;
        }
    }
}
