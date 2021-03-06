using ModelPersistence.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ModelPersistence.Persistence
{
    public class TeacherRepository : IRepository<Teacher>
    {
        public void Add(Teacher teacher)
        {
            string commandText = "INSERT INTO Teacher(TeacherName, PhoneNumber, SocialSecurityNumber, ChildAttestExpirationDate, Active)" +
                "VALUES ('@TeacherName', '@PhoneNumber', '@SocialSecurityNumber', '@ChildAttestExpirationDate', @Active); ";

            using (SqlConnection connection = new SqlConnection(StaticConnection.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(commandText, connection);

                command.Parameters.AddWithValue("@TeacherName", teacher.TeacherName);
                command.Parameters.AddWithValue("@PhoneNumber", teacher.PhoneNumber);
                command.Parameters.AddWithValue("@SocialSecurityNumber", teacher.SocialSecurityNumber);
                command.Parameters.AddWithValue("@ChildAttestExpirationDate", teacher.ChildAttestExpirationDate);
                command.Parameters.AddWithValue("@Active", teacher.Active);

                command.ExecuteNonQuery();

            }
        }

        public IEnumerable<Teacher> GetAll()
        {
            throw new NotImplementedException();
        }

        public Teacher GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public void Update(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
