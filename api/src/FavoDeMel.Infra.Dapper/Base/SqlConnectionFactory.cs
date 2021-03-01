using System.Data;
using System.Data.SqlClient;

namespace FavoDeMel.Infra.Dapper.Base
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;
        private IDbConnection _connection;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection OpenConnection()
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
            }

            return _connection;
        }

        public void Dispose()
        {
            if (_connection is not null && _connection.State == ConnectionState.Open)
            {
                _connection.Dispose();
            }
        }
    }
}
