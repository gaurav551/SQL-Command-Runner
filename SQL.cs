using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace COmmandRunner
{
    public  class SQL
    {
       
      public List<string> GetStudentNames()
      {
          List<string> names = new List<string>();
          string connectionString = "server=DESKTOP-7EO032A\\SQLEXPRESS;Initial Catalog=pathshala;Trusted_Connection=True; MultipleActiveResultSets=True;";
          SqlConnection sqlconnection = new SqlConnection(connectionString);
          sqlconnection.Open();
          string query = "select Fullname from students";
          SqlCommand command = new SqlCommand(query, sqlconnection);
          SqlDataReader reader = command.ExecuteReader();
          while(reader.Read())
          {
              names.Add(reader["FullName"].ToString());

          }
          sqlconnection.Close();
          return names;

      }
    }
}