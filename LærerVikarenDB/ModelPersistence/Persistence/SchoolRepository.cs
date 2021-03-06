using ModelPersistence.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ModelPersistence.Persistence
{
    public class SchoolRepository : IRepository<School>
    {
        List<School> schools = new List<School>();

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
            schools.Add(school);
        }

        public IEnumerable<School> GetAll()
        {
            string commandText = $"SELECT * FROM School;";
            List<School> allSchools = new List<School>();
            School school = new School();

            using (SqlConnection connection = new SqlConnection(StaticConnection.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(commandText, connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    school.SchoolID = (int)reader[0];
                    school.SchoolName = (string)reader[1];
                    school.SchoolAddress = (string)reader[2];
                    allSchools.Add(school);
                }
            }
            schools = allSchools;
            return schools;
        }

        public School GetById(int id)
        {
            string commandText = $"SELECT * FROM School WHERE SchoolID = @ID;";
            School school = new School();

            using (SqlConnection connection = new SqlConnection(StaticConnection.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@ID", id);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    school.SchoolID = (int)reader[0];
                    school.SchoolName = (string)reader[1];
                    school.SchoolAddress = (string)reader[2];                  
                }
            }

            return school;
        }

        public void Remove(School school)
        {
            string commandText = "DELETE FROM School" +
            "WHERE SchoolID = @SchoolID;";

            using (SqlConnection connection = new SqlConnection(StaticConnection.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@SchoolID", school.SchoolID);
                command.ExecuteNonQuery();
            }
            schools.Remove(school);
        }

        public void Update(School school)
        {
            string commandText = "UPDATE School" +
            "SET SchoolName = @SchoolName, SchoolAddress = @SchoolAddress" +
            "WHERE SchoolID = @SchooldID;";

            using (SqlConnection connection = new SqlConnection(StaticConnection.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@SchoolID", school.SchoolID);
                command.Parameters.AddWithValue("@SchoolName", school.SchoolName);
                command.Parameters.AddWithValue("@SchoolAddress", school.SchoolAddress);
                command.ExecuteNonQuery();
            }

            School temp = new School();
            foreach (var item in schools)
            {
                if (item.SchoolID == school.SchoolID)
                {
                    temp = item;
                }
            }
            schools.Remove(temp);
            schools.Add(school);
        }
    }
    }
}
