using System;
using System.Collections.Generic;
using System.Linq;
using TheMovies.Models;

namespace TheMovies.Repos
{
    public class CinemaMovieShowBookingRepo  // Inherit from the interface as shown in the DCD
    {
        private List<CinemaMovieShowBooking> entries;

        public CinemaMovieShowBookingRepo()
        {
            entries = new List<CinemaMovieShowBooking>();
            LoadRepo();
        }

        // Implement the interface methods shown in the DCD!

        private void LoadRepo()
        {
            // Implement this method !
        }
        private void SaveRepo()
        {
            // Implement this method !
        }
    }
}
