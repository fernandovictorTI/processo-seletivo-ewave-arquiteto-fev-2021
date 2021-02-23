using FavoDeMel.Domain.Dto;
using Flunt.Notifications;
using MediatR;
using System.Collections.Generic;

namespace FavoDeMel.Domain.Querys.Comanda.Consultas
{
    public class ObterComandasQuery : Notifiable<Notification>, IRequest<IEnumerable<ComandaDto>>
    {
        public ObterComandasQuery(int pagina, int quantidade)
        {
            Pagina = pagina;
            Quantidade = quantidade;
        }

        public int Pagina { get; set; }
        public int Quantidade { get; set; }
    }
}
