using Flunt.Notifications;
using MediatR;
using System;

namespace FavoDeMel.Domain.Querys.Base
{
    public class ObterPorIdQuery<T> : Notifiable<Notification>, IRequest<T>
    {
        public ObterPorIdQuery(Guid id)
        {
            if (id == default(Guid) || id == Guid.Empty)
                throw new ArgumentNullException(nameof(id), "ID não deve ser nulo.");

            Id = id;
        }

        public Guid Id { get; set; }
    }
}
