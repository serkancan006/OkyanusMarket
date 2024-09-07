using Microsoft.Data.SqlClient;
using System.Data;

namespace OkyanusHangfire.Context
{
    public class DapperMsSqlContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperMsSqlContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
