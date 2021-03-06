using ModelPersistence.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ModelPersistence.Persistence
{
    public class SubstituteRepository : IRepository<Substitute>
    {
        public void Add(Substitute substitute)
        {
            string commandText = "INSERT INTO Substitute(SubstituteHours, SchoolID, CourseID, AvailableID)" +
                "VALUES (@SubstituteHours, @SchoolID, @CourseID, @AvailableID);";

            using (SqlConnection connection = new SqlConnection(StaticConnection.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(commandText, connection);

                command.Parameters.AddWithValue("@SubstituteHours", substitute.SubstituteHours);
                command.Parameters.AddWithValue("@SchoolID", substitute.SchoolID);
                command.Parameters.AddWithValue("@CourseID", substitute.CourseID);
                command.Parameters.AddWithValue("@AvailableID", substitute.AvaiableID);

                command.ExecuteNonQuery();

            }
        }

        public IEnumerable<Substitute> GetAll()
        {
            throw new NotImplementedException();
        }

        public void GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Substitute substitute)
        {
            throw new NotImplementedException();
        }

        public void Update(Substitute substitute)
        {
            throw new NotImplementedException();
        }
    }
}
