using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            bool alreadyExist = false;

            foreach (CinemaMovieShowBooking item in entries)
            {
                if (obj.Equals(item))
                {
                    alreadyExist = true;
                    break;
                }
            }

            if (!alreadyExist)
            {
                entries.Add(obj);
            }         
            
        }

        public void Delete(CinemaMovieShowBooking obj)
        {
            List<CinemaMovieShowBooking> temp = new List<CinemaMovieShowBooking>();
            foreach (CinemaMovieShowBooking item in entries)
            {
                if (obj.CinemaName == item.CinemaName && obj.CinemaTown == item.CinemaTown)
                {
                    temp.Add(item);
                }
            }
            foreach (CinemaMovieShowBooking item in temp)
            {
                entries.Remove(item);
            }

        }

        public void Update(CinemaMovieShowBooking obj, CinemaMovieShowBooking newValues)
        {
            foreach (CinemaMovieShowBooking item in entries)
            {
                if (obj.CinemaName == item.CinemaName && obj.CinemaTown == item.CinemaTown)
                {
                    item.CinemaName = newValues.CinemaName;
                    item.CinemaTown = newValues.CinemaTown;
                }
            }
        }

        private void LoadRepo()
        {
            string fileName = "repos\\Ex41-TheMovies.CSV";
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

        private void SaveRepo()
        {

        }

        //private void SaveRepo()
        //{
        //    string fileName = "repos\\Ex41-TheMovies.CSV";
        //    //string fileName = @"E:\GitLab\dmu-2020-exercise-materials\Supplerende materiale\Ex41-TheMovies.CSV";

        //    //string addLines
        //    var addLines = (from item in entries
        //                    select new object[]
        //                    {
        //                    item.CinemaName + item.CinemaTown + item.ShowDateTime +
        //                    item.MovieTitle + item.MovieGenre + item.MovieDuration +
        //                    item.MovieDirector + item.MovieReleaseDate + item.BookingMail +
        //                    item.BookingPhone,
        //                    string.Format("\"{0}\"")
        //                    }).ToList();

        //    var csv = new StringBuilder();
        //    addLines.ForEach(line =>
        //    {
        //        csv.AppendLine(string.Join(";", line));
        //    });

        //    File.WriteAllText(fileName, csv.ToString());

        //}

    }
}
