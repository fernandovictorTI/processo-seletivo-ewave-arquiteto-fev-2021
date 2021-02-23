using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Querys.Base;
using System;

namespace FavoDeMel.Domain.Querys.Garcom.Consultas
{
    public class ObterGarcomQuery : ObterPorIdQuery<GarcomDto>
    {
        public ObterGarcomQuery(Guid id) : base(id)
        {
        }
    }
}
