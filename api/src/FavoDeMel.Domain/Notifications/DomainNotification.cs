using Flunt.Notifications;
using MediatR;
using System.Collections.Generic;

namespace FavoDeMel.Domain.Notifications
{
    public class DomainNotification : INotification
    {
        public IReadOnlyCollection<Notification> Erros { get; set; }
    }
}
