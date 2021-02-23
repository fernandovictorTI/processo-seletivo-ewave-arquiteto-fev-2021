using Flunt.Notifications;
using MediatR;
using System;

namespace FavoDeMel.Domain.Querys.Base
{
    public class ObterPorIdQuery<T> : Notifiable<Notification>, IRequest<T>
    {
        public ObterPorIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
