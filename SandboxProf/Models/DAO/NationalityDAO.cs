using Microsoft.Data.SqlClient;
using SandboxProf.Models.Domain;

namespace SandboxProf.Models.DAO
{
    public class NationalityDAO
    {
        private readonly IConfiguration _configuration;
        string connectionString;

        public NationalityDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public List<Nationality> Get()
        {
            List<Nationality> nationalities = new List<Nationality>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand("GetNationalities", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read()) //while there's data to read...
                {
                    nationalities.Add(new Nationality
                    {
                        Id = Convert.ToInt32(sqlDataReader["Id"]),
                        Name = sqlDataReader["Name"].ToString(),
                        Code = sqlDataReader["Code"].ToString()
                    });

                }

                connection.Close();

            }
            return nationalities;
        }
    }
}
