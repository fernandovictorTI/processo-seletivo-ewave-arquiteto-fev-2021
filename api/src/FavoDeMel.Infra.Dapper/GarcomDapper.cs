using Dapper;
using FavoDeMel.Domain.Dapper;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Infra.Dapper.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Infra.Dapper
{
    public class GarcomDapper : IGarcomDapper
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GarcomDapper(
            ISqlConnectionFactory sqlConnectionFactory
            )
        {
            this._sqlConnectionFactory = sqlConnectionFactory;
        }

        private readonly string SQL = @"
            SELECT 
               [IDGarcom] as Id
              ,[IDGarcom]
              ,[Nome]
              ,[Telefone]
            FROM Garcom
            ORDER BY 1 desc
            OFFSET @pagina ROWS
            FETCH NEXT @quantidade ROWS ONLY;
        ";

        public async Task<IEnumerable<GarcomDto>> ObterGarcons(int quantidade, int pagina)
        {
            using var connection = this._sqlConnectionFactory.OpenConnection();
            return await connection.QueryAsync<GarcomDto>(SQL, new { quantidade, pagina });
        }
    }
}
