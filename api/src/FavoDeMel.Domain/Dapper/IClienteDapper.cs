using FavoDeMel.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Domain.Dapper
{
    public interface IClienteDapper
    {
        Task<IEnumerable<ClienteDto>> ObterClientes(int quantidade, int pagina);
    }
}
