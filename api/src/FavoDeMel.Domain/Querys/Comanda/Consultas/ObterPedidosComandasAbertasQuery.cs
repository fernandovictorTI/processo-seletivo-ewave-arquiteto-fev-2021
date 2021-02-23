using FavoDeMel.Domain.Dto;
using Flunt.Notifications;
using MediatR;
using System.Collections.Generic;

namespace FavoDeMel.Domain.Querys.Comanda.Consultas
{
    public class ObterPedidosComandasAbertasQuery:  Notifiable, IRequest<IEnumerable<PedidosComandaDto>>
    {
    }
}
