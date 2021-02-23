using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Repositories.Base;

namespace FavoDeMel.Domain.Repositories
{
    public interface IClienteRepository : IRepository<Cliente, ClienteDto>
    {
        bool PossuiNomeCadastrado(Cliente cliente);
    }
}
