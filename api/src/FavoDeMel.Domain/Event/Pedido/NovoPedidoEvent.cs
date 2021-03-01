﻿using FavoDeMel.Domain.Exceptions;
using MediatR;
using System;

namespace FavoDeMel.Domain.Event.Pedido
{
    public class NovoPedidoEvent : IRequest<bool>
    {
        public NovoPedidoEvent(Guid idPedido)
        {
            if (idPedido == Guid.Empty)
                throw new IDValidoException(nameof(idPedido));

            IDPedido = idPedido;
        }

        public Guid IDPedido { get; set; }
    }
}
