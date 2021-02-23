using AutoMapper;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infra.EF.Data.Repositories.Base;
using PacoEvento.Infra.Data.Context;
using System.Linq;

namespace FavoDeMel.Infra.EF.Repositories
{
    public class GarcomRepository : Repository<Garcom, GarcomDto>, IGarcomRepository
    {
        public GarcomRepository(FavoDeMelContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public bool PossuiNomeCadastrado(Garcom garcom)
        {
            return GetAll().Where(c => c.Nome.Nome.Equals(garcom.Nome.Nome)).Any();
        }
    }
}
