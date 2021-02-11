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
            CinemaMovieShowBooking temp = id as CinemaMovieShowBooking;
            foreach (var item in entries)
            {
                if (temp.BookingPhone == item.BookingPhone)
                {
                    temp = item;
                }
            }

            return temp;
            //ud fra tlf nummer kunne man lave et id, så man kan finde hvad en bestemt kunde har booket.
            throw new NotImplementedException();

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

                //if (obj.CinemaName != default
                // && obj.CinemaTown != default
                // && obj.MovieTitle != default
                // && obj.MovieDuration != default
                // && obj.ShowDateTime != default
                // && obj.BookingPhone == item.BookingPhone
                // && obj.BookingMail == item.BookingMail)
                //{
                //    throw new ArgumentException("dublet");
                //}


            }

            entries.Add(obj);
            SaveRepo();
           
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

            SaveRepo();
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

            SaveRepo();

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
                    if (data.Length>9)
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

        private void SaveRepo()
        {
            string fileName = "repos\\Ex41-TheMovies.CSV";

            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                writer.WriteLine("Biograf;By;Forestillingstidspunkt;Filmtitel;Filmgenre;" +
                    "Filmvarighed;Filminstruktør;Premieredato;Bookingmail;Bookingtelefonnummer");
                
                foreach (CinemaMovieShowBooking item in entries)
                {
                    
                    int hour = item.MovieDuration / 60;
                    int minutes = item.MovieDuration % 60;

                    if(item.CinemaName != default
                    && item.CinemaTown != default
                    && item.MovieTitle != default
                    && item.MovieDirector != default
                    && item.MovieDuration != default
                    && item.MovieGenre != default
                    && item.ShowDateTime != default
                    && item.BookingPhone != default
                    && item.BookingMail != default)
                    {
                        writer.Write($"{item.CinemaName};");
                        writer.Write($"{item.CinemaTown};");
                        writer.Write($"{item.ShowDateTime.ToString()};");
                        writer.Write($"{item.MovieTitle};");
                        writer.Write($"{item.MovieGenre};");
                        writer.Write($"{hour:00}:{minutes:00};");
                        writer.Write($"{item.MovieDirector};");
                        writer.Write($"{item.MovieReleaseDate.ToShortDateString()};");
                        writer.Write($"{item.BookingMail};");
                        writer.WriteLine($"{item.BookingPhone}"); 
                    }

                    //writer.WriteLine(item.CinemaName + ";" 
                    //    + item.CinemaTown + ";" 
                    //    + item.ShowDateTime.ToString() + ";" 
                    //    + item.MovieTitle + ";" 
                    //    + item.MovieGenre + ";" 
                    //    + $"{hour:00}:{minutes:00}" + ";" 
                    //    + item.MovieDirector + ";" 
                    //    + item.MovieReleaseDate.ToShortDateString() + ";" 
                    //    + item.BookingMail + ";" 
                    //    + item.BookingPhone);
                }
            }
            
        }

        //private void SaveRepo()
        //{
            
        //    string fileName = @"./Data/Ex41-TheMovies.csv";
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
