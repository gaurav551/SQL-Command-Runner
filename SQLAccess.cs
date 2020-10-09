using System.Data.SqlClient;

namespace COmmandRunner
{
    public static class SQLAccess
    {
        public static void GetNames()
        {
          string connectionString = "server=DESKTOP-7EO032A\\SQLEXPRESS;Initial Catalog=pathshala;Trusted_Connection=True; MultipleActiveResultSets=True;";
          SqlConnection connection = new SqlConnection(connectionString);
          connection.Open();
          string query = "SELECT fullname, Class from students";
          SqlCommand command = new SqlCommand(query, connection);
          SqlDataReader reader = command.ExecuteReader();
          while(reader.Read())
          {
              System.Console.WriteLine(reader["FullName"].ToString());
              System.Console.WriteLine(reader["Class"]);
          }
        }
    }
}