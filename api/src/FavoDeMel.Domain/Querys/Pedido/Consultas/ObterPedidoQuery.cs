using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Querys.Base;
using System;

namespace FavoDeMel.Domain.Querys.Pedido.Consultas
{
    public class ObterPedidoQuery : ObterPorIdQuery<PedidoDto>
    {
        public ObterPedidoQuery(Guid id) : base(id)
        {
        }
    }
}
