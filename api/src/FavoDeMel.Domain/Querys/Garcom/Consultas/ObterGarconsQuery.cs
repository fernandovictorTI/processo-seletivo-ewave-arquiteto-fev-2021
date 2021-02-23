using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Querys.Base;

namespace FavoDeMel.Domain.Querys.Garcom.Consultas
{
    public class ObterGarconsQuery : PaginacaoQuery<GarcomDto>
    {
        public ObterGarconsQuery(int pagina, int quantidade) : base(pagina, quantidade)
        {
        }
    }
}
