using Dapper;
using FavoDeMel.Domain.Dapper;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Infra.Dapper.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Infra.Dapper
{
    public class ComandaDapper : IComandaDapper
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public ComandaDapper(
            ISqlConnectionFactory sqlConnectionFactory
            )
        {
            this._sqlConnectionFactory = sqlConnectionFactory;
        }

        private readonly string SQL = @"
            WITH UltimoPedidoComanda as (
            SELECT
	            ROW_NUMBER() OVER(PARTITION BY c.IDComanda ORDER BY DataPedido desc) RowNumber,
	            c.IDComanda, c.Numero, IDPedido, DataPedido
            FROM
            Comanda c 
            LEFT JOIN Pedido p on c.IDComanda = p.IDComanda)
            SELECT
                up.IDComanda as Id,
	            up.IDComanda,
	            up.Numero,
                IDPedido,
	            (SELECT TOP 1 Situacao FROM HistoricoPedido o where o.IDPedido = up.IDPedido order by Data desc) Situacao
            FROM UltimoPedidoComanda up
            WHERE RowNumber = 1
            ORDER BY up.Numero
            OFFSET @pagina ROWS
            FETCH NEXT @quantidade ROWS ONLY;
        ";

        private readonly string SQL_OBTER_ULTIMO_HISTORICOPEDIDO_COMANDA = @"
            WITH UltimoPedidoComanda as (
            SELECT
	            ROW_NUMBER() OVER(PARTITION BY c.IDComanda ORDER BY DataPedido desc) RowNumber,
	            c.IDComanda, IDPedido, DataPedido
            FROM
            Comanda c 
            INNER JOIN Pedido p on c.IDComanda = p.IDComanda
            WHERE c.IDComanda = @idComanda
            )
            SELECT TOP 1 hp.* FROM UltimoPedidoComanda up
            INNER JOIN HistoricoPedido hp on up.IDPedido = hp.IDPedido
            WHERE RowNumber = 1
            order by hp.Data desc
        ";

        private readonly string SQL_OBTER_PEDIDOS_COMANDAS_ABERTAS = @"
            WITH UltimoPedidoComanda as (
            SELECT
	            ROW_NUMBER() OVER(PARTITION BY c.IDComanda ORDER BY DataPedido desc) RowNumber,
	            c.IDComanda, c.Numero, IDPedido, DataPedido
            FROM
            Comanda c 
            INNER JOIN Pedido p on c.IDComanda = p.IDComanda
            )
            SELECT
	            up.IDPedido,
	            up.Numero,
	            up.IDComanda,
	            pp.IDProdutoPedido,
	            p.Nome as NomeProduto,
	            p.Valor,
	            pp.Quantidade,
	            up.DataPedido,
	            g.IDGarcom,
	            g.Nome as NomeGarcom,
                cl.IDCliente,
                cl.Nome as NomeCliente,
	            (SELECT TOP 1 Situacao FROM HistoricoPedido o where o.IDPedido = up.IDPedido order by Data desc) as Situacao
            FROM UltimoPedidoComanda up
            INNER JOIN ProdutoPedido pp on pp.IDPedido = up.IDPedido
            INNER JOIN Produto p on p.IDProduto = pp.IDProduto
            INNER JOIN Pedido ped on ped.IDPedido = up.IDPedido
            INNER JOIN Cliente cl on cl.IDCliente = ped.IDCliente
            INNER JOIN Garcom g on g.IDGarcom = ped.IDGarcom
            WHERE RowNumber = 1
            AND (SELECT TOP 1 Situacao FROM HistoricoPedido o where o.IDPedido = up.IDPedido order by Data desc) not in (4, 5)
            order by up.DataPedido
        ";

        public async Task<IEnumerable<ComandaDto>> ObterComandas(int quantidade, int pagina)
        {
            using (var connection = this._sqlConnectionFactory.OpenConnection())
            {
                return await connection.QueryAsync<ComandaDto>(SQL, new { quantidade, pagina });
            }
        }

        public async Task<HistoricoPedidoDto> ObterUltimoHistoricoPedidoComanda(Guid idComanda)
        {
            using (var connection = _sqlConnectionFactory.OpenConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<HistoricoPedidoDto>(SQL_OBTER_ULTIMO_HISTORICOPEDIDO_COMANDA, new { idComanda });
            }
        }

        public async Task<IEnumerable<PedidosComandaDto>> ObterPedidosComandasAbertas()
        {
            using (var connection = _sqlConnectionFactory.OpenConnection())
            {
                return await connection.QueryAsync<PedidosComandaDto>(SQL_OBTER_PEDIDOS_COMANDAS_ABERTAS);
            }
        }
    }
}
