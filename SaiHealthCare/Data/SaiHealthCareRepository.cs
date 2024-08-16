using System;
using System.Data.SqlClient;

namespace SaiHealthCare.Data
{
    public class SaiHealthCareRepository
    {
        private SqlConnection _connection;

        public SaiHealthCareRepository()
        {
            string connectionString = "Data Source=.;Initial Catalog=DB_SaiHealthCare;Integrated Security=True; TrustServerCertificate = True";
            _connection = new SqlConnection(connectionString);
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }
    }
}
