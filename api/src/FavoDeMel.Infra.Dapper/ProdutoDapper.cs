using Dapper;
using FavoDeMel.Domain.Dapper;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Infra.Dapper.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Infra.Dapper
{
    public class ProdutoDapper : IProdutoDapper
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public ProdutoDapper(
            ISqlConnectionFactory sqlConnectionFactory
            )
        {
            this._sqlConnectionFactory = sqlConnectionFactory;
        }

        private readonly string SQL = @"
            SELECT 
               [IDProduto] as Id
              ,[IDProduto]
              ,[Nome]
              ,[Valor]
            FROM Produto
            order by 1 desc
            OFFSET @pagina ROWS
            FETCH NEXT @quantidade ROWS ONLY;
        ";

        public async Task<IEnumerable<ProdutoDto>> ObterProdutos(int quantidade, int pagina)
        {
            using var connection = this._sqlConnectionFactory.OpenConnection();
            return await connection.QueryAsync<ProdutoDto>(SQL, new { quantidade, pagina });
        }
    }
}
