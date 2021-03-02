using FavoDeMel.Domain.Dto;
using Flunt.Notifications;
using MediatR;
using System;

namespace FavoDeMel.Domain.Querys.Comanda.Consultas
{
    public class ObterUltimoHistoricoPedidoComandaQuery : Notifiable<Notification>, IRequest<HistoricoPedidoDto>
    {
        public ObterUltimoHistoricoPedidoComandaQuery(Guid iDComanda)
        {
            if (iDComanda == default(Guid))
                throw new ArgumentNullException(nameof(iDComanda), "ID da comanda não deve ser null.");

            IDComanda = iDComanda;
        }

        public Guid IDComanda { get; set; }
    }
}
