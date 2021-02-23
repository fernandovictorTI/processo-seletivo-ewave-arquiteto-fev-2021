using FavoDeMel.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Domain.Dapper
{
    public interface IPedidoDapper
    {
        Task<IEnumerable<PedidoDto>> ObterPedidos(int quantidade, int pagina);
    }
}
