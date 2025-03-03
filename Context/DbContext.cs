using Microsoft.Data.SqlClient;
using System.Data;

namespace NotesServer.Context
{
    public class DbContext
    {
        private readonly string _connectionString;

        public DbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("NotesCon");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
