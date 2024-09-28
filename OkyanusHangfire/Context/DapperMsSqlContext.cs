using Microsoft.Data.SqlClient;
using System.Data;

namespace OkyanusHangfire.Context
{
    public class DapperMsSqlContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly string _connectionStringHangfire;
        public DapperMsSqlContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
            _connectionStringHangfire = _configuration.GetConnectionString("HangfireConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
        public IDbConnection CreateConnectionHangfire() => new SqlConnection(_connectionStringHangfire);
    }
}
