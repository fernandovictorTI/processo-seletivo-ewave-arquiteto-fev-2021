using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Querys.Base;
using System;

namespace FavoDeMel.Domain.Querys.Cliente.Consultas
{
    public class ObterClienteQuery : ObterPorIdQuery<ClienteDto>
    {
        public ObterClienteQuery(Guid id) : base(id)
        {
        }
    }
}
