using AutoMapper;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infra.EF.Data.Repositories.Base;
using PacoEvento.Infra.Data.Context;
using System.Linq;

namespace FavoDeMel.Infra.EF.Repositories
{
    public class ComandaRepository : Repository<Comanda, ComandaDto>, IComandaRepository
    {
        public ComandaRepository(
            FavoDeMelContext context,
            IMapper mapper)
            : base(context, mapper)
        {
        }

        public bool PossuiNumeroComandaCadastrada(Comanda comanda)
        {
            return GetAll().Where(c => c.NumeroComanda.Numero == comanda.NumeroComanda.Numero).Any();
        }
    }
}
