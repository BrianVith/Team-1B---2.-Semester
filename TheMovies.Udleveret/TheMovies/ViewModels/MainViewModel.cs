using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovies.Models;
using TheMovies.Repos;

namespace TheMovies.ViewModels
{
    public class MainViewModel
    {
        private CinemaMovieShowBookingRepo repo = new CinemaMovieShowBookingRepo();

        public ObservableCollection<CinemaVM> Cinemas { get; set; } = new ObservableCollection<CinemaVM>();
        public ObservableCollection<MovieVM> Movies { get; set; } = new ObservableCollection<MovieVM>();
        public ObservableCollection<ShowVM> Shows { get; set; } = new ObservableCollection<ShowVM>();
        public ObservableCollection<BookingVM> Bookings { get; set; } = new ObservableCollection<BookingVM>();


        CinemaVM selectedCinema;
        public CinemaVM SelectedCinema
        {
            get { return selectedCinema; }
            set
            {
                if (value != selectedCinema)
                {
                    selectedCinema = value;
                    //RefreshVMs();
                }
            }
        }

        private MovieVM selectedMovie;
        public MovieVM SelectedMovie
        {
            get { return selectedMovie; }
            set
            {
                if (value != selectedMovie)
                {
                    selectedMovie = value;
                    //RefreshVMs();
                }
            }
        }

        private ShowVM selectedShow;
        public ShowVM SelectedShow
        {
            get { return selectedShow; }
            set
            {
                if (value != selectedShow)
                {
                    selectedShow = value;
                    //RefreshVMs();
                }
            }
        }


        private BookingVM selectedBooking;
        public BookingVM SelectedBooking 
        {
            get { return selectedBooking; }
            set
            {
                if (value != selectedBooking)
                {
                    selectedBooking = value;
                    //RefreshVMs();
                }
            }
        }

        public CinemaVM LockedCinema { get; set; }
        public MovieVM LockedMovie { get; set; }
        public ShowVM LockedShow { get; set; }
        public BookingVM LockedBooking { get; set; }

        public MainViewModel()
        {
            RefreshVMs();
        }


        public void AddCinema(string cinemaName, string cinemaTown)
        {
            try
            {
                CinemaMovieShowBooking cinema = new CinemaMovieShowBooking { CinemaName = cinemaName, CinemaTown = cinemaTown };
                if (LockedMovie != null)
                {
                    cinema.MovieTitle = LockedMovie.Title;
                    cinema.MovieGenre = LockedMovie.Genre;
                    cinema.MovieDuration = LockedMovie.Duration;
                    cinema.MovieDirector = LockedMovie.Director;
                    cinema.MovieReleaseDate = LockedMovie.ReleaseDate;
                }
                if (SelectedShow != null)
                {
                    cinema.ShowDateTime = SelectedShow.ShowDateTime;
                }
                if (SelectedBooking != null)
                {
                    cinema.BookingMail = SelectedBooking.BookingMail;
                    cinema.BookingPhone = SelectedBooking.BookingPhone;
                }

                repo.Add(cinema);

                CinemaVM cinemaVM = new CinemaVM { Cinema = cinemaName, Town = cinemaTown, Locked = false };
                Cinemas.Add(cinemaVM);

                SelectedCinema = cinemaVM;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateCinema(CinemaVM cinemaVM, string newCinemaName, string newCinemaTown)
        {
            CinemaMovieShowBooking fromCinema = new CinemaMovieShowBooking { CinemaName = cinemaVM.Cinema, CinemaTown = cinemaVM.Town };
            CinemaMovieShowBooking toCinema = new CinemaMovieShowBooking { CinemaName = newCinemaName, CinemaTown = newCinemaTown };

            try
            {
                repo.Update(fromCinema, toCinema);

                cinemaVM.Cinema = newCinemaName;
                cinemaVM.Town = newCinemaTown;

                RefreshVMs();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteCinema(CinemaVM cinemaVM)
        {
            CinemaMovieShowBooking deleteCinema = new CinemaMovieShowBooking { CinemaName = cinemaVM.Cinema, CinemaTown = cinemaVM.Town };

            try
            {
                repo.Delete(deleteCinema);
                Cinemas.Remove(cinemaVM);
                RefreshVMs();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void AddMovie(string movieTitle, string movieGenre, int movieDuration, string movieDirector, DateTime movieReleaseDate)
        {
            try
            {
                CinemaMovieShowBooking movie = new CinemaMovieShowBooking { MovieTitle = movieTitle, MovieGenre = movieGenre, MovieDuration = movieDuration, MovieDirector = movieDirector, MovieReleaseDate = movieReleaseDate };
                if (LockedCinema != null)
                {
                    movie.CinemaName = LockedCinema.Cinema;
                    movie.CinemaTown = LockedCinema.Town;
                }
                if (LockedShow != null)
                {
                    movie.ShowDateTime = LockedShow.ShowDateTime;
                }
                if (LockedBooking != null)
                {
                    movie.BookingMail = LockedBooking.BookingMail;
                    movie.BookingPhone = LockedBooking.BookingPhone;
                }

                repo.Add(movie);

                MovieVM movieVM = new MovieVM 
                { 
                    Title = movieTitle, 
                    Genre = movieGenre, 
                    Duration = movieDuration, 
                    Director = movieDirector, 
                    ReleaseDate = movieReleaseDate,
                    Locked = false
                };
                Movies.Add(movieVM);

                SelectedMovie = movieVM;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateMovie(MovieVM movieVM, string newMovieTitle, string newMovieGenre, int newMovieDuration, string newMovieDirector, DateTime newMovieReleaseDate)
        {
            CinemaMovieShowBooking fromMovie = new CinemaMovieShowBooking 
            { 
                MovieTitle = movieVM.Title, 
                MovieGenre = movieVM.Genre, 
                MovieDuration = movieVM.Duration, 
                MovieDirector = movieVM.Director, 
                MovieReleaseDate = movieVM.ReleaseDate 
            };
            CinemaMovieShowBooking toMovie = new CinemaMovieShowBooking 
            {
                MovieTitle = newMovieTitle,
                MovieGenre = newMovieGenre,
                MovieDuration = newMovieDuration,
                MovieDirector = newMovieDirector,
                MovieReleaseDate = newMovieReleaseDate
            };

            try
            {
                repo.Update(fromMovie, toMovie);

                movieVM.Title = newMovieTitle;
                movieVM.Genre = newMovieGenre;
                movieVM.Duration = newMovieDuration;
                movieVM.Director = newMovieDirector;
                movieVM.ReleaseDate = newMovieReleaseDate;

                RefreshVMs();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteMovie(MovieVM movieVM)
        {
            CinemaMovieShowBooking deleteMovie = new CinemaMovieShowBooking { MovieTitle = movieVM.Title, MovieGenre = movieVM.Genre, MovieDuration = movieVM.Duration, MovieDirector = movieVM.Director, MovieReleaseDate = movieVM.ReleaseDate };

            try
            {
                repo.Delete(deleteMovie);
                Movies.Remove(movieVM);
                RefreshVMs();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddShow(DateTime showDateTime)
        {
            try
            {
                CinemaMovieShowBooking show = new CinemaMovieShowBooking { ShowDateTime = showDateTime };
                if (LockedCinema != null)
                {
                    show.CinemaName = LockedCinema.Cinema;
                    show.CinemaTown = LockedCinema.Town;
                }
                if (LockedMovie != null)
                {
                    show.MovieTitle = LockedMovie.Title;
                    show.MovieGenre = LockedMovie.Genre;
                    show.MovieDuration = LockedMovie.Duration;
                    show.MovieDirector = LockedMovie.Director;
                    show.MovieReleaseDate = LockedMovie.ReleaseDate;
                }
                if (LockedBooking != null)
                {
                    show.BookingMail = LockedBooking.BookingMail;
                    show.BookingPhone = LockedBooking.BookingPhone;
                }

                repo.Add(show);

                ShowVM showVM = new ShowVM { ShowDateTime = showDateTime, Locked = false };
                Shows.Add(showVM);

                SelectedShow = showVM;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateShow(ShowVM showVM, DateTime newShowDateTime)
        {
            CinemaMovieShowBooking fromShow = new CinemaMovieShowBooking { ShowDateTime = showVM.ShowDateTime };
            CinemaMovieShowBooking toShow = new CinemaMovieShowBooking { ShowDateTime = newShowDateTime };

            try
            {
                repo.Update(fromShow, toShow);

                showVM.ShowDateTime = newShowDateTime;

                RefreshVMs();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteShow(ShowVM showVM)
        {
            CinemaMovieShowBooking deleteShow = new CinemaMovieShowBooking { ShowDateTime = showVM.ShowDateTime };

            try
            {
                repo.Delete(deleteShow);
                Shows.Remove(showVM);
                RefreshVMs();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void AddBooking(string bookingMail, string bookingPhone)
        {
            try
            {
                CinemaMovieShowBooking booking = new CinemaMovieShowBooking { BookingMail = bookingMail, BookingPhone = bookingPhone };
                if (LockedCinema != null)
                {
                    booking.CinemaName = LockedCinema.Cinema;
                    booking.CinemaTown = LockedCinema.Town;
                }
                if (LockedMovie != null)
                {
                    booking.MovieTitle = LockedMovie.Title;
                    booking.MovieGenre = LockedMovie.Genre;
                    booking.MovieDuration = LockedMovie.Duration;
                    booking.MovieDirector = LockedMovie.Director;
                    booking.MovieReleaseDate = LockedMovie.ReleaseDate;
                }
                if (LockedShow != null)
                {
                    booking.ShowDateTime = LockedShow.ShowDateTime;
                }

                repo.Add(booking);

                BookingVM bookingVM = new BookingVM { BookingMail = bookingMail, BookingPhone = bookingPhone, Locked = false };
                Bookings.Add(bookingVM);

                SelectedBooking = bookingVM;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateBooking(BookingVM bookingVM, string newBookingMail, string newBookingPhone)
        {
            CinemaMovieShowBooking fromBooking = new CinemaMovieShowBooking { BookingMail = bookingVM.BookingMail, BookingPhone = bookingVM.BookingPhone };
            CinemaMovieShowBooking toBooking = new CinemaMovieShowBooking { BookingMail = newBookingMail, BookingPhone = newBookingPhone };

            try
            {
                repo.Update(fromBooking, toBooking);

                bookingVM.BookingMail = newBookingMail;
                bookingVM.BookingPhone = newBookingPhone;

                RefreshVMs();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteBooking(BookingVM bookingVM)
        {
            CinemaMovieShowBooking deleteBooking = new CinemaMovieShowBooking { BookingMail = bookingVM.BookingMail, BookingPhone = bookingVM.BookingPhone };

            try
            {
                repo.Delete(deleteBooking);
                Bookings.Remove(bookingVM);
                RefreshVMs();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RefreshVMs()
        {
            var selection = repo.GetAll();

            Cinemas.Clear();
            Movies.Clear();
            Shows.Clear();
            Bookings.Clear();

            if (LockedCinema != null)
            {
                Cinemas.Add(new CinemaVM { Cinema = LockedCinema.Cinema, Town = LockedCinema.Town, Locked = true });
                selection = selection.Where(sb => LockedCinema.Cinema == sb.CinemaName && LockedCinema.Town == sb.CinemaTown);
            }

            if (LockedMovie != null)
            {
                Movies.Add(new MovieVM
                {
                    Title = LockedMovie.Title,
                    Genre = LockedMovie.Genre,
                    Duration = LockedMovie.Duration,
                    Director = LockedMovie.Director,
                    ReleaseDate = LockedMovie.ReleaseDate,
                    Locked = true
                });
                selection = selection.Where(sb => LockedMovie.Title == sb.MovieTitle && LockedMovie.Duration == sb.MovieDuration && LockedMovie.Director == sb.MovieDirector && LockedMovie.Genre == sb.MovieGenre);
            }

            if (LockedShow != null)
            {
                Shows.Add(new ShowVM { ShowDateTime = LockedShow.ShowDateTime, Locked = true });
                selection = selection.Where(sb => LockedShow.ShowDateTime == sb.ShowDateTime);
            }

            if (LockedBooking != null)
            {
                Bookings.Add(new BookingVM { BookingMail = LockedBooking.BookingMail, BookingPhone = LockedBooking.BookingPhone, Locked = true });
                selection = selection.Where(sb => LockedBooking.BookingMail == sb.BookingMail && LockedBooking.BookingPhone == sb.BookingPhone);
            }

            foreach (CinemaMovieShowBooking sb in selection)
            {
                if (sb.CinemaName != default && sb.CinemaTown != default)
                {
                    if (LockedCinema == null)
                    {
                        if (Cinemas.Where(c => c.Cinema == sb.CinemaName && c.Town == sb.CinemaTown).Count() == 0)
                            Cinemas.Add(new CinemaVM { Cinema = sb.CinemaName, Town = sb.CinemaTown, Locked = false });
                    }
                }

                if (sb.MovieTitle != default && sb.MovieGenre != default && sb.MovieDirector != default && sb.MovieDuration != default && sb.MovieReleaseDate != default)
                {
                    if (LockedMovie == null)
                    {
                        if (Movies.Where(m => m.Title == sb.MovieTitle && m.Duration == sb.MovieDuration && m.Director == sb.MovieDirector && m.Genre == sb.MovieGenre).Count() == 0)
                            Movies.Add(new MovieVM
                            {
                                Title = sb.MovieTitle,
                                Genre = sb.MovieGenre,
                                Duration = sb.MovieDuration,
                                Director = sb.MovieDirector,
                                ReleaseDate = sb.MovieReleaseDate,
                                Locked = false
                            });
                    }
                }

                if (sb.ShowDateTime != default)
                {
                    if (LockedShow == null)
                    {
                        if (Shows.Where(s => s.ShowDateTime == sb.ShowDateTime).Count() == 0)
                            Shows.Add(new ShowVM { ShowDateTime = sb.ShowDateTime, Locked = false });
                    }
                }

                if (sb.BookingMail != default && sb.BookingPhone != default)
                {
                    if (LockedBooking == null)
                    {
                        if (Bookings.Where(b => b.BookingMail == sb.BookingMail && b.BookingPhone == sb.BookingPhone).Count() == 0)
                            Bookings.Add(new BookingVM { BookingMail = sb.BookingMail, BookingPhone = sb.BookingPhone, Locked = false });
                    }
                }
            }
        }

    }
}
