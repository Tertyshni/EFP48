using Microsoft.Data.SqlClient;
using System.Data;

namespace EFP48.DapperCore.Entity
{
    public class DapperContext
    {
        private readonly string _connectionString;
        internal IEnumerable<object> users;

        public DapperContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<object> Posts { get; internal set; }
        public IEnumerable<object> Users { get; internal set; }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
