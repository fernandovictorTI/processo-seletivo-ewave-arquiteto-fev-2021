using FavoDeMel.Domain.Enums;
using Flunt.Notifications;
using MediatR;
using System;

namespace FavoDeMel.Domain.Command.Pedido
{
    public class AlterarSituacaoPedidoCommand : Notifiable, IRequest<Guid>
    {
        public AlterarSituacaoPedidoCommand(Guid iDPedido, EnumSituacaoPedido situacao)
        {
            IDPedido = iDPedido;
            Situacao = situacao;
        }

        public Guid IDPedido { get; set; }
        public EnumSituacaoPedido Situacao { get; set; }
    }
}
