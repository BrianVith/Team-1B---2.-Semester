using ModelPersistence.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ModelPersistence.Persistence
{
    public class AvailableRepository : IRepository<Available>
    {
        public void Add(Available available)
        {
            string commandText = "INSERT INTO Available(AvailableDate, TeacherID, TimePeriodID)" +
                "VALUES ('@AvailableDate', '@TeacherID', '@TimePeriodID');";

            using (SqlConnection connection = new SqlConnection(StaticConnection.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(commandText, connection);

                command.Parameters.AddWithValue("@CourseName", available.AvailableDate);
                command.Parameters.AddWithValue("@TeacherID", available.TeacherID);
                command.Parameters.AddWithValue("@TimePeriodID", available.TimePeriodID);

                command.ExecuteNonQuery();

            }
        }

        public IEnumerable<Available> GetAll()
        {
            throw new NotImplementedException();
        }

        public Available GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Available available)
        {
            throw new NotImplementedException();
        }

        public void Update(Available available)
        {
            throw new NotImplementedException();
        }
    }
}
