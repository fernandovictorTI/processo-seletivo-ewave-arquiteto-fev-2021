using FavoDeMel.Application.QueryModels;
using FavoDeMel.Application.ViewModels;
using FavoDeMel.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Application.Interfaces
{
    public interface IComandaService : IServiceBase<ComandaViewModel, ComandaQueryModel, ComandaDto>
    {
        Task<IEnumerable<PedidosComandaDto>> ObterPedidosComandasAbertas();
    }
}
