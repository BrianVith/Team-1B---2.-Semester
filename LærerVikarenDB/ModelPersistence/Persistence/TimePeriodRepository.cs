using ModelPersistence.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ModelPersistence.Persistence
{
    public class TimePeriodRepository : IRepository<TimePeriod>
    {
        public void Add(TimePeriod timePeriod)
        {
            string commandText = "INSERT INTO TimePeriod(TimePeriod)" +
                "VALUES('@TimePeriod');";

            using (SqlConnection connection = new SqlConnection(StaticConnection.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(commandText, connection);

                command.Parameters.AddWithValue("@TimePeriod", timePeriod.TimePeriodAvailable);

                command.ExecuteNonQuery();

            }
        }

        public IEnumerable<TimePeriod> GetAll()
        {
            throw new NotImplementedException();
        }

        public TimePeriod GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(TimePeriod timePeriod)
        {
            throw new NotImplementedException();
        }

        public void Update(TimePeriod timePeriod)
        {
            throw new NotImplementedException();
        }
    }
}
