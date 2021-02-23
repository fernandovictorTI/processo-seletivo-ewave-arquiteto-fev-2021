using AutoMapper;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infra.EF.Data.Repositories.Base;
using PacoEvento.Infra.Data.Context;
using System.Linq;

namespace FavoDeMel.Infra.EF.Repositories
{
    public class ClienteRepository : Repository<Cliente, ClienteDto>, IClienteRepository
    {
        public ClienteRepository(
            FavoDeMelContext context,
            IMapper mapper)
            : base(context, mapper)
        {
        }

        public bool PossuiNomeCadastrado(Cliente cliente)
        {
            return GetAll().Where(c => c.Nome.Nome.Equals(cliente.Nome.Nome)).Any();
        }
    }
}
