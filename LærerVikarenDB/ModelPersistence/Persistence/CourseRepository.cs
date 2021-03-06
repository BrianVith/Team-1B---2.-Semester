using ModelPersistence.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ModelPersistence.Persistence
{
    public class CourseRepository : IRepository<Course>
    {
        public void Add(Course course)
        {
            string commandText = "INSERT INTO Course(CourseName)" +
                "VALUES ('@CourseName');";

            using (SqlConnection connection = new SqlConnection(StaticConnection.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(commandText, connection);

                command.Parameters.AddWithValue("@CourseName", course.CourseName);

                command.ExecuteNonQuery();
            
            }
        }

        public IEnumerable<Course> GetAll()
        {
            throw new NotImplementedException();
        }

        public void GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Course course)
        {
            throw new NotImplementedException();
        }

        public void Update(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
