using AutoMapper;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infra.EF.Data.Repositories.Base;
using PacoEvento.Infra.Data.Context;
using System.Linq;

namespace FavoDeMel.Infra.EF.Repositories
{
    public class ProdutoRepository : Repository<Produto, ProdutoDto>, IProdutoRepository
    {
        public ProdutoRepository(FavoDeMelContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public bool PossuiProdutoCadastrado(Produto produto)
        {
            return GetAll().Where(c => c.Nome.Nome.Equals(produto.Nome.Nome)).Any();
        }
    }
}
