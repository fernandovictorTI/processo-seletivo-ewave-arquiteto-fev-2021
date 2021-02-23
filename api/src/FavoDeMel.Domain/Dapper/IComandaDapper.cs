using FavoDeMel.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Domain.Dapper
{
    public interface IComandaDapper
    {
        Task<IEnumerable<ComandaDto>> ObterComandas(int quantidade, int pagina);
        Task<HistoricoPedidoDto> ObterUltimoHistoricoPedidoComanda(Guid idComanda);
        Task<IEnumerable<PedidosComandaDto>> ObterPedidosComandasAbertas();
    }
}
