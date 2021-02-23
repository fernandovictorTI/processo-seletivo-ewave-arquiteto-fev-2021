using Dapper;
using FavoDeMel.Domain.Dapper;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Infra.Dapper.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Infra.Dapper
{
    public class ClienteDapper : IClienteDapper
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public ClienteDapper(
            ISqlConnectionFactory sqlConnectionFactory
            )
        {
            this._sqlConnectionFactory = sqlConnectionFactory;
        }

        private readonly string SQL = @"
            SELECT 
                 [IDCliente]
                ,[IDCliente] as Id
                ,[Nome]
                ,[DataCriacao]
            FROM Cliente
            ORDER BY DataCriacao desc
            OFFSET @pagina ROWS
            FETCH NEXT @quantidade ROWS ONLY;
        ";

        public async Task<IEnumerable<ClienteDto>> ObterClientes(int quantidade, int pagina)
        {
            using (var connection = this._sqlConnectionFactory.OpenConnection())
            {
                return await connection.QueryAsync<ClienteDto>(SQL, new { quantidade, pagina });
            }
        }
    }
}
