using MediatR;

namespace Domain.Events.Event
{
    public sealed class EventModifyEvent : INotification
    {
        public string eventName { get; set; }
        public List<string> userEmails { get; set; }

        public readonly string action;

        public enum Action { 
            DELETE,
            UPDATE,
        }

        public EventModifyEvent(string eventName, List<string> userEmails, Action _action)
        {
            this.eventName = eventName;
            this.userEmails = userEmails;
            switch (_action)
            {
                case Action.DELETE:
                    action = "deleted";
                    break;
                case Action.UPDATE:
                    action = "updated";
                    break;
            }
        }
    }
}
