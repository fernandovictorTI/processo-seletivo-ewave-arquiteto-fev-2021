using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Querys.Base;
using System;

namespace FavoDeMel.Domain.Querys.Comanda.Consultas
{
    public class ObterComandaQuery : ObterPorIdQuery<ComandaDto>
    {
        public ObterComandaQuery(Guid id) : base(id)
        {
        }
    }
}
