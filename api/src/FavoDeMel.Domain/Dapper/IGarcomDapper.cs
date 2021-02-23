using FavoDeMel.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Domain.Dapper
{
    public interface IGarcomDapper
    {
        Task<IEnumerable<GarcomDto>> ObterGarcons(int quantidade, int pagina);
    }
}
