using Dapper;
using FavoDeMel.Domain.Dapper;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Infra.Dapper.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Infra.Dapper
{
    public class PedidoDapper : IPedidoDapper
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public PedidoDapper(
            ISqlConnectionFactory sqlConnectionFactory
            )
        {
            this._sqlConnectionFactory = sqlConnectionFactory;
        }

        private readonly string SQL = @"
            SELECT 
               p.IDPedido as Id
              ,p.IDPedido
              ,g.IDGarcom
              ,g.Nome as NomeGarcom
              ,c.IDComanda
              ,cl.IDCliente
              ,cl.Nome as NomeCliente
              ,c.Numero as NumeroComanda
              ,[DataPedido]
            FROM Pedido p
            INNER JOIN Garcom g on p.IDGarcom = g.IDGarcom
            INNER JOIN Comanda c on p.IDComanda = c.IDComanda
            INNER JOIN Cliente cl on p.IDCliente = cl.IDCliente
            ORDER BY DataPedido desc
            OFFSET @pagina ROWS
            FETCH NEXT @quantidade ROWS ONLY;
        ";

        public async Task<IEnumerable<PedidoDto>> ObterPedidos(int quantidade, int pagina)
        {
            using (var connection = this._sqlConnectionFactory.OpenConnection())
            {
                return await connection.QueryAsync<PedidoDto>(SQL, new { quantidade, pagina });
            }
        }
    }
}
