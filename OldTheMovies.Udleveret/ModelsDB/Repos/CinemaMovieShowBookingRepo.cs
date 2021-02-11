using System;
using System.Collections.Generic;
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
            // Implement this method !

            throw new NotImplementedException();
        }

        public void Delete(CinemaMovieShowBooking obj)
        {
            // Implement this method !

            throw new NotImplementedException();
        }

        public void Update(CinemaMovieShowBooking obj, CinemaMovieShowBooking newValues)
        {
            // Implement this method !

            throw new NotImplementedException();
        }

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
