using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;

namespace FavoDeMel.Domain.Querys.Base
{
    public class PaginacaoQuery<T> : Notifiable<Notification>, IRequest<IEnumerable<T>>
    {
        public PaginacaoQuery(int pagina, int quantidade)
        {
            if (pagina <= 0)
                throw new ArgumentNullException(nameof(pagina), "Pagina atual da paginação deve ser maior que 0.");

            if (quantidade <= 0)
                throw new ArgumentNullException(nameof(quantidade), "Quantidade atual da paginação deve ser maior que 0.");


            Pagina = pagina;
            Quantidade = quantidade;
        }

        public int Pagina { get; set; }
        public int Quantidade { get; set; }
    }
}
