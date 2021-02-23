using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Querys.Base;

namespace FavoDeMel.Domain.Querys.Cliente.Consultas
{
    public class ObterClientesQuery : PaginacaoQuery<ClienteDto>
    {
        public ObterClientesQuery(int pagina, int quantidade) : base(pagina, quantidade)
        {
        }
    }
}
