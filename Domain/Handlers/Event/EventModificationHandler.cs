using Domain.Events.Event;
using Domain.Interfaces;
using MediatR;

namespace Domain.Handlers.Event
{
    public class EventModificationHandler(IEmailSender emailSender) : INotificationHandler<EventModifyEvent>
    {
        public async Task Handle(EventModifyEvent notification, CancellationToken cancellationToken)
        {
            foreach (string email in notification.userEmails)
            {
                await emailSender.SendEmailAsync($"{email}",
                                        $"Inforamtion about {notification.eventName} was modified",
                                        $"Event {notification.eventName} was {notification.action}");
            }
        }

    }
}
