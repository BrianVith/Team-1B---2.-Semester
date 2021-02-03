using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TheMovies.Models;

namespace TheMovies.Repos
{
    public class CinemaMovieShowBookingRepo : IRepository<CinemaMovieShowBooking>
    {
        private List<CinemaMovieShowBooking> entries;

        public CinemaMovieShowBookingRepo()
        {
            entries = new List<CinemaMovieShowBooking>();
            LoadRepo();
        }

        public IEnumerable<CinemaMovieShowBooking> GetAll()
        {
            // Return a copy of the internal datastructure

            return entries.ToList();
        }

        public CinemaMovieShowBooking GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Add(CinemaMovieShowBooking obj)
        {
            entries.Add(obj);
        }

        public void Delete(CinemaMovieShowBooking obj)
        {
            entries.Remove(obj);
        }

        public void Update(CinemaMovieShowBooking obj, CinemaMovieShowBooking newValues)
        {
            obj = newValues;
        }

        private void LoadRepo()
        {
            string fileName = "TheMovies.CSV"; 
            using (StreamReader reader = new StreamReader(fileName))
            {
                reader.ReadLine();
                string str = reader.ReadLine();
                string[] data;
                string[] durationData;

                while (str != null)
                {
                    data = str.Split(new char[] { ';' }, StringSplitOptions.None);

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
                    

                    Add(movieTheater);                   
             
                    str = reader.ReadLine();
                }
            }     
        }
        private void SaveRepo()
        {
            // Implement this method !
        }
    }
}
