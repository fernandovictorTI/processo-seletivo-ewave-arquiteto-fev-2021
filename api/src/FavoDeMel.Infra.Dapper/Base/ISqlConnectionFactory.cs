using System.Data;

namespace FavoDeMel.Infra.Dapper.Base
{
    public interface ISqlConnectionFactory
    {
        IDbConnection OpenConnection();
    }
}
