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
            IDComanda = iDComanda;
        }

        public Guid IDComanda { get; set; }
    }
}
