using FavoDeMel.Domain.Entities;
using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FavoDeMel.Domain.Command.Pedido
{
    public class CriarPedidoCommand : Notifiable, IRequest<Guid>
    {
        public CriarPedidoCommand(
            Guid iDGarcom,
            Guid idComanda,
            Guid idCliente,
            List<ProdutoPedido> produtos)
        {
            IDGarcom = iDGarcom;
            IDComanda = idComanda;
            IDCliente = idCliente;
            Produtos = produtos;

            if (!produtos.Any())
                AddNotification("CriarPedidoCommand.Produtos", "Produtos do pedido são obrigatorios.");
        }

        public Guid IDGarcom { get; set; }
        public Guid IDComanda { get; set; }
        public Guid IDCliente { get; set; }
        public IEnumerable<ProdutoPedido> Produtos { get; set; }
    }
}
