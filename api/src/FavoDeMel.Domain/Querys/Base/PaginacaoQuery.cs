using Flunt.Notifications;
using MediatR;
using System.Collections.Generic;

namespace FavoDeMel.Domain.Querys.Base
{
    public class PaginacaoQuery<T> : Notifiable, IRequest<IEnumerable<T>>
    {
        public PaginacaoQuery(int pagina, int quantidade)
        {
            Pagina = pagina;
            Quantidade = quantidade;
        }

        public int Pagina { get; set; }
        public int Quantidade { get; set; }
    }
}
