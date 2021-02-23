﻿using MediatR;
using System;

namespace FavoDeMel.Domain.Event.Pedido
{
    public class RemovidoProdutoPedidoEvent : IRequest<bool>
    {
        public RemovidoProdutoPedidoEvent(Guid idPedido)
        {
            IDPedido = idPedido;
        }

        public Guid IDPedido { get; set; }
    }
}
