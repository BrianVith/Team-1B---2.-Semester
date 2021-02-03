using System;
using System.Collections.Generic;
using System.Text;

namespace TheMovies.Models
{
    public class CinemaMovieShowBooking
    {
        public string CinemaName { get; set; }
        public string CinemaTown { get; set; }
        public DateTime ShowDateTime { get; set; }
        public string MovieTitle { get; set; }
        public string MovieGenre { get; set; }
        public int MovieDuration { get; set; }  // The duration of the movie in minutes
        public string MovieDirector { get; set; }
        public DateTime MovieReleaseDate { get; set; }
        public string BookingMail { get; set; }
        public string BookingPhone { get; set; }

        public override string ToString()
        {
            return $"Cinema: {CinemaName}, Town: {CinemaTown}, Show: {ShowDateTime}, Movie: {MovieTitle}, Genre: {MovieGenre}, Duration: {MovieDuration}, Director: {MovieDirector}, Release: {MovieReleaseDate}, Booking mail: {BookingMail}, Booking phone: {BookingPhone}";
        }
    }
}