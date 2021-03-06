using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TheMovies.Models;
using System.Data.SqlClient;
using System.Data;

namespace TheMovies.Repos
{
    public class CinemaMovieShowBookingRepo : IRepository<CinemaMovieShowBooking>
    {
        private List<CinemaMovieShowBooking> entries;
        string connectionString = "Server=10.56.8.35;Database=B_DB35_2020;User Id=B_STUDENT35;Password=B_OPENDB35";
        

        public CinemaMovieShowBookingRepo()
        {
            entries = new List<CinemaMovieShowBooking>();
            LoadRepoFromCSV();
            //LoadRepo();
            //ResetDatabase();
        
        }

        public CinemaMovieShowBooking GetById(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CinemaMovieShowBooking> GetAll()
        {
            // Return a copy of the internal datastructure

            return entries.ToList();
        }

        public void Add(CinemaMovieShowBooking obj)
        {

            foreach (CinemaMovieShowBooking item in entries)
            {

                if (obj.CinemaName == item.CinemaName && item.CinemaName != default
                    && obj.CinemaTown == item.CinemaTown && item.CinemaTown != default
                    && obj.MovieTitle == default
                    && obj.MovieDirector == default
                    && obj.MovieDuration == default
                    && obj.MovieGenre == default
                    && obj.ShowDateTime == default
                    && obj.BookingPhone == default
                    && obj.BookingMail == default)
                {
                    throw new ArgumentException("dublet");
                }

                if (obj.CinemaName != default
                    && obj.CinemaTown != default
                    && obj.MovieTitle == item.MovieTitle && item.MovieTitle != default
                    && obj.MovieDuration == item.MovieDuration && item.MovieDuration != default
                    && obj.ShowDateTime == default
                    && obj.BookingPhone == default
                    && obj.BookingMail == default)
                {
                    throw new ArgumentException("dublet");
                }

                if (obj.CinemaName != default
                    && obj.CinemaTown != default
                    && obj.MovieTitle != default
                    && obj.MovieDuration != default
                    && obj.ShowDateTime == item.ShowDateTime && item.ShowDateTime != default
                    && obj.BookingPhone == default
                    && obj.BookingMail == default)
                {
                    throw new ArgumentException("dublet");
                }


                if (obj.CinemaName == item.CinemaName && item.CinemaName != default
                    && obj.CinemaTown == item.CinemaTown && item.CinemaTown != default
                    && obj.MovieTitle == item.MovieTitle && item.MovieTitle != default
                    && obj.MovieDuration == item.MovieDuration && item.MovieDuration != default
                    && obj.ShowDateTime == item.ShowDateTime && item.ShowDateTime != default
                    && obj.BookingPhone == item.BookingPhone && item.BookingPhone != default
                    && obj.BookingMail == item.BookingMail && item.BookingMail != default)
                {
                    throw new ArgumentException("dublet");
                }

                if (obj.CinemaName != default
                 && obj.CinemaTown != default
                 && obj.MovieTitle != default
                 && obj.MovieDuration != default
                 && obj.ShowDateTime != default
                 && obj.BookingPhone == item.BookingPhone
                 && obj.BookingMail == item.BookingMail)
                {
                    throw new ArgumentException("dublet");
                }


            }
            
            entries.Add(obj);

            string commandText = "INSERT INTO Booking (" +
            "cinemaTown,cinemaName,movieTitle," +
            "movieGenre,movieDirector,movieDuration," +
            "movieReleaseDate,showDateTime,bookingPhone,bookingMail)"
            + "VALUES (@cinemaTown,@cinemaName," +
            "@movieTitle,@movieGenre,@movieDirector," +
            "@movieDuration,@movieReleaseDate,@showDateTime," +
            "@bookingPhone,@bookingMail);";

            SaveRepo(commandText,obj);

        }

        public void Delete(CinemaMovieShowBooking obj)
        {
            List<CinemaMovieShowBooking> temp = new List<CinemaMovieShowBooking>();
            foreach (CinemaMovieShowBooking item in entries)
            {
                if (obj.CinemaName == item.CinemaName && obj.CinemaName != default
                    && obj.CinemaTown == item.CinemaTown && obj.CinemaTown != default)
                {
                    temp.Add(item);
                }

                if (obj.MovieTitle == item.MovieTitle && obj.MovieTitle != default
                    && obj.MovieDuration == item.MovieDuration && obj.MovieDuration != default
                    && obj.MovieDirector == item.MovieDirector && obj.MovieDirector != default
                    && obj.MovieGenre == item.MovieGenre && obj.MovieGenre != default)
                {
                    temp.Add(item);
                }

                if (obj.ShowDateTime == item.ShowDateTime && obj.ShowDateTime != default)
                {
                    temp.Add(item);
                }

                if (obj.BookingMail == item.BookingMail && obj.BookingMail != default
                    && obj.BookingPhone == item.BookingPhone && obj.BookingPhone != default)
                {
                    temp.Add(item);
                }

            }

            foreach (CinemaMovieShowBooking item in temp)
            {
                entries.Remove(item);
            }

            //string commandText = " DELETE FROM _____";
            //SaveRepo(commandText);
        }

        public void Update(CinemaMovieShowBooking obj, CinemaMovieShowBooking newValues)
        {
            foreach (CinemaMovieShowBooking item in entries)
            {
                if (obj.CinemaName == item.CinemaName
                    && obj.CinemaTown == item.CinemaTown)
                {
                    item.CinemaName = newValues.CinemaName;
                    item.CinemaTown = newValues.CinemaTown;
                }

                if (obj.MovieGenre == item.MovieGenre
                    && obj.MovieDuration == item.MovieDuration
                    && obj.MovieDirector == item.MovieDirector
                    && obj.MovieTitle == item.MovieTitle
                    && obj.MovieReleaseDate == item.MovieReleaseDate)
                {
                    item.MovieGenre = newValues.MovieGenre;
                    item.MovieDuration = newValues.MovieDuration;
                    item.MovieDirector = newValues.MovieDirector;
                    item.MovieTitle = newValues.MovieTitle;
                    item.MovieReleaseDate = newValues.MovieReleaseDate;
                }

                if (obj.ShowDateTime == item.ShowDateTime)
                {
                    item.ShowDateTime = newValues.ShowDateTime;
                }

                if (obj.BookingMail == item.BookingMail
                    && obj.BookingPhone == item.BookingPhone)
                {
                    item.BookingPhone = newValues.BookingPhone;
                    item.BookingMail = newValues.BookingMail;
                }

            }

            string commandText = "";
            //SaveRepo(commandText,obj);
        }

        // Implement the interface methods shown in the DCD!

        private void SaveRepo(string commandText, CinemaMovieShowBooking item)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //connection.ConnectionString = "database-sti";        

                int hour = item.MovieDuration / 60;
                int minutes = item.MovieDuration % 60;
                string hourMinutes = $"{hour:00}:{minutes:00}";

                if (item.CinemaName != default && item.CinemaTown != default
                && item.MovieTitle != default && item.MovieDirector != default
                && item.MovieDuration != default && item.MovieReleaseDate != default
                && item.MovieGenre != default && item.ShowDateTime != default
                && item.BookingPhone != default && item.BookingMail != default)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(commandText, connection);

                    command.Parameters.AddWithValue("@cinemaName", item.CinemaName);
                    command.Parameters.AddWithValue("@cinemaTown", item.CinemaTown);
                    command.Parameters.AddWithValue("@movieTitle", item.MovieTitle);
                    command.Parameters.AddWithValue("@movieGenre", item.MovieGenre);
                    command.Parameters.AddWithValue("@movieDirector", item.MovieDirector);
                    command.Parameters.AddWithValue("@movieDuration", item.MovieDuration);
                    command.Parameters.AddWithValue("@movieReleaseDate", item.MovieReleaseDate);
                    command.Parameters.AddWithValue("@showDateTime", item.ShowDateTime);
                    command.Parameters.AddWithValue("@bookingPhone", item.BookingPhone);
                    command.Parameters.AddWithValue("@bookingMail", item.BookingMail);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void LoadRepo()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string[] hourMinutes;
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM OldBooking;", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CinemaMovieShowBooking booking = new CinemaMovieShowBooking();

                    booking.BookingID = (int)reader[0];
                    booking.CinemaName = (string)reader[1];
                    booking.CinemaTown = (string)reader[2];
                    booking.MovieTitle = (string)reader[3];
                    booking.MovieGenre = (string)reader[4];
                    booking.MovieDirector = (string)reader[5];
                    hourMinutes = ((string)reader[6]).Split(new char[] { ':' }, StringSplitOptions.None);
                    int hour = int.Parse(hourMinutes[0]);
                    int minutes = int.Parse(hourMinutes[1]);
                    booking.MovieDuration = (hour * 60) + minutes;
                    booking.MovieReleaseDate = Convert.ToDateTime(reader[7]);
                    booking.ShowDateTime = Convert.ToDateTime(reader[8]);
                    booking.BookingPhone = (string)reader[9];
                    booking.BookingMail = (string)reader[10];

                    if (booking != null) 
                        entries.Add(booking);
                }
            }
        }


        private void LoadRepoFromCSV()
        {
            string fileName = "TheMovies.CSV";
            //string fileName = @"E:\GitLab\dmu-2020-exercise-materials\Supplerende materiale\Ex41-TheMovies.CSV";
            using (StreamReader reader = new StreamReader(fileName))
            {
                reader.ReadLine();
                string str = reader.ReadLine();
                string[] data;
                string[] durationData;

                while (str != null)
                {
                    data = str.Split(new char[] { ';' }, StringSplitOptions.None);
                    if (data.Length > 9)
                    {
                        CinemaMovieShowBooking movieTheater = new CinemaMovieShowBooking();

                        movieTheater.CinemaName = data[0];
                        movieTheater.CinemaTown = data[1];
                        movieTheater.ShowDateTime = Convert.ToDateTime(data[2]);
                        movieTheater.MovieTitle = data[3];
                        movieTheater.MovieGenre = data[4];

                        durationData = data[5].Split(new char[] { ':' }, StringSplitOptions.None);
                        int hour = int.Parse(durationData[0]);
                        int minutes = int.Parse(durationData[1]);
                        movieTheater.MovieDuration = (hour * 60) + minutes;
                        movieTheater.MovieDirector = data[6];
                        movieTheater.MovieReleaseDate = Convert.ToDateTime(data[7]);
                        movieTheater.BookingMail = data[8];
                        movieTheater.BookingPhone = data[9];

                        entries.Add(movieTheater);

                        str = reader.ReadLine();
                    }
                }
            }
        }

        private void ResetDatabase()
        {
            //Int32 rowsAffected;
            string commandText = "INSERT INTO OldBooking (" +
            "cinemaName," +
            "cinemaTown," +
            "movieTitle," +
            "movieGenre," +
            "movieDirector," +
            "movieDuration," +
            "movieReleaseDate," +
            "showDateTime," +
            "bookingPhone," +
            "bookingMail)"
            + "VALUES (" +
            "@cinemaName, " +
            "@cinemaTown," +
            "@movieTitle," +
            "@movieGenre," +
            "@movieDirector," +
            "@movieDuration," +
            "@movieReleaseDate," +
            "@showDateTime," +
            "@bookingPhone," +
            "@bookingMail);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //connection.ConnectionString = "database-sti";

                connection.Open();

                foreach (CinemaMovieShowBooking item in entries)
                {
                    int hour = item.MovieDuration / 60;
                    int minutes = item.MovieDuration % 60;
                    string hourMinutes = $"{hour:00}:{minutes:00}";

                    if (item.CinemaName != default
                    && item.CinemaTown != default
                    && item.MovieTitle != default
                    && item.MovieDirector != default
                    && item.MovieDuration != default
                    && item.MovieReleaseDate != default
                    && item.MovieGenre != default
                    && item.ShowDateTime != default
                    && item.BookingPhone != default
                    && item.BookingMail != default)
                    {
                        SqlCommand command = new SqlCommand(commandText, connection);
                        command.Parameters.AddWithValue("@cinemaName", item.CinemaName);
                        command.Parameters.AddWithValue("@cinemaTown", item.CinemaTown);
                        command.Parameters.AddWithValue("@movieTitle", item.MovieTitle);
                        command.Parameters.AddWithValue("@movieGenre", item.MovieGenre);
                        command.Parameters.AddWithValue("@movieDirector", item.MovieDirector);
                        command.Parameters.AddWithValue("@movieDuration", hourMinutes);
                        command.Parameters.AddWithValue("@movieReleaseDate", item.MovieReleaseDate);
                        command.Parameters.AddWithValue("@showDateTime", item.ShowDateTime);
                        command.Parameters.AddWithValue("@bookingPhone", item.BookingPhone);
                        command.Parameters.AddWithValue("@bookingMail", item.BookingMail);

                        command.ExecuteNonQuery();

                    }
                }
            }

        }


    }
}
