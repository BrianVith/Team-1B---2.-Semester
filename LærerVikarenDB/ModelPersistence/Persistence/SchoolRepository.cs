using ModelPersistence.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ModelPersistence.Persistence
{
    public class SchoolRepository : IRepository<School>
    {
        public void Add(School school)
        {
            string commandText = "INSERT INTO School(SchoolName, SchoolAddress)" +
               "VALUES ('@SchoolName', '@SchoolAddress');";

            using (SqlConnection connection = new SqlConnection(StaticConnection.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(commandText, connection);

                command.Parameters.AddWithValue("@SchoolName", school.SchoolName);
                command.Parameters.AddWithValue("@SchoolAddress", school.SchoolAddress);

                command.ExecuteNonQuery();

            }
        }

        public IEnumerable<School> GetAll()
        {
            throw new NotImplementedException();
        }

        public void GetById(int id)
        {

            throw new NotImplementedException();
        }

        public void Remove(School entity)
        {
            throw new NotImplementedException();
        }

        public void Update(School entity)
        {
            throw new NotImplementedException();
        }
    }
}
