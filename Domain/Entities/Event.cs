using Domain.Exceptions;
using Domain.Validators;
using FluentValidation.Results;
using System.Text;

namespace Domain.Entities
{
    public class Event : IEntity
    {
        public Guid id { get; set; }
        public string name { get; set ; }
        public string description { get; set ; }
        public string plan { get; set ; }
        public Person spicker { get; set ; }
        public Person organizer { get; set ; }
        public DateTime time { get; set ; }
        public Address address { get; set ; }
        public string category { get; set ; }
        public int maxParticipants { get; set ; }
        public int freePlaces { get; set ; }
        public List<string> images { get; set ; }

        public Event() { }

        private Event(string name, 
            string description, string plan, 
            Person spicker, Person organizer, 
            DateTime time, Address address,
            string category, int maxParticipants, int freePlaces,
            List<string> imagePathes)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.plan = plan;
            this.spicker = spicker;
            this.organizer = organizer;
            this.time = time;
            this.address = address;
            this.category = category;
            this.maxParticipants = maxParticipants;
            this.freePlaces = freePlaces;
            this.images = imagePathes;
        }

        public void SetId(Guid id) => this.id = id;

        public void Validate()
        {
            EventValidator validator = new EventValidator();
            ValidationResult result = validator.Validate(this);
            if (!result.IsValid)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    stringBuilder.AppendLine(error.ErrorMessage);
                }
                throw new EventCreationException(stringBuilder.ToString());
            }
        }

        public static Event Create(string name,
            string description, string plan,
            Person spicker, Person organizer,
            DateTime time, Address address,
            string category, int maxParticipants, int freePlaces,
            List<string> imagePathes)
        {
            var e = new Event(name, description,
                plan, spicker, organizer, time,
                address, category, maxParticipants, freePlaces,imagePathes);
            EventValidator validator = new EventValidator();
            ValidationResult result = validator.Validate(e);
            if (!result.IsValid)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    stringBuilder.AppendLine(error.ErrorMessage);
                }
                throw new EventCreationException(stringBuilder.ToString());
            }
            return e;
        }
    }
}
