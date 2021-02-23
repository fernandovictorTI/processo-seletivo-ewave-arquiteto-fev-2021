using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Querys.Base;

namespace FavoDeMel.Domain.Querys.Pedido.Consultas
{
    public class ObterPedidosQuery : PaginacaoQuery<PedidoDto>
    {
        public ObterPedidosQuery(int pagina, int quantidade) : base(pagina, quantidade)
        {
        }
    }
}
