using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheMovies.ViewModels;
using TheMovies.Views;

namespace TheMovies
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mvm = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();

            // Setting culture
            this.Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);

            // Setting data context
            DataContext = mvm;

            // Setup sorting
            lbCinemas.Items.SortDescriptions.Add(new SortDescription("CinemaName", ListSortDirection.Ascending));
            lbCinemas.Items.IsLiveSorting = true;
            lbCinemas.Items.LiveSortingProperties.Add("CinemaName");

            lbMovies.Items.SortDescriptions.Add(new SortDescription("Title", ListSortDirection.Ascending));
            lbShows.Items.SortDescriptions.Add(new SortDescription("ShowDateTime", ListSortDirection.Ascending));
        }

        private void btnAddCinema_Click(object sender, RoutedEventArgs e)
        {
            AddEditCinemaDialog cd = new AddEditCinemaDialog();
            cd.Title = "Tilføj ny biograf";

            if ((bool)cd.ShowDialog())
            {
                try
                {
                    mvm.AddCinema(cd.tbCinemaName.Text, cd.tbCinemaTown.Text);
                }
                catch (NotImplementedException)
                {
                    MessageBox.Show("Denne funktionalitet er endnu ikke implementeret!", "Kan ikke tilføje biograf", MessageBoxButton.OK);
                }
                catch (Exception)
                {
                    MessageBox.Show($"Biografen {cd.tbCinemaName.Text} i {cd.tbCinemaTown.Text} eksisterer allerede. Prøv igen.", "Kan ikke tilføje biograf", MessageBoxButton.OK);
                }
            }
        }
        private void btnEditCinema_Click(object sender, RoutedEventArgs e)
        {
            if (mvm.SelectedCinema != null)
            {
                AddEditCinemaDialog cd = new AddEditCinemaDialog();
                cd.Title = "Redigér biograf";
                cd.tbCinemaName.Text = mvm.SelectedCinema.Cinema;
                cd.tbCinemaTown.Text = mvm.SelectedCinema.Town;

                if ((bool)cd.ShowDialog())
                {
                    if (mvm.SelectedCinema.Cinema != cd.tbCinemaName.Text || mvm.SelectedCinema.Town != cd.tbCinemaTown.Text)
                    {
                        mvm.UpdateCinema(mvm.SelectedCinema, cd.tbCinemaName.Text, cd.tbCinemaTown.Text);
                    }
                }
            }
            else
            {
                MessageBox.Show($"Ingen biograf er valgt. Vælg først en.", "Kan ikke redigere biograf", MessageBoxButton.OK);
            }
        }
        private void btnDeleteCinema_Click(object sender, RoutedEventArgs e)
        {
            if (mvm.SelectedCinema != null)
            {
                MessageBoxResult answer = MessageBox.Show($"Er du sikker på, at du vil slette biografen {mvm.SelectedCinema.Cinema} i {mvm.SelectedCinema.Town}?", "Slet biograf", MessageBoxButton.YesNo);

                if (answer == MessageBoxResult.Yes)
                {
                    mvm.DeleteCinema(mvm.SelectedCinema);
                }
            }
            else
            {
                MessageBox.Show($"Ingen biograf er valgt. Vælg først en.", "Kan ikke slette biograf", MessageBoxButton.OK);
            }
        }
        private void btnLockReleaseCinema_Click(object sender, RoutedEventArgs e)
        {
            if (mvm.LockedCinema == null)
            {
                if (lbCinemas.SelectedItem != null)
                {
                    mvm.LockedCinema = (CinemaVM)lbCinemas.SelectedItem;
                    btnCinemaLockRelease.Content = "Frigiv";
                    mvm.RefreshVMs();
                }
                else
                {
                    MessageBox.Show($"Ingen biograf er valgt. Vælg først en.", "Lås biograf", MessageBoxButton.OK);
                }
            }
            else
            {
                mvm.LockedCinema = null;
                btnCinemaLockRelease.Content = "Lås";
                mvm.RefreshVMs();
            }
        }

        private void btnAddMovie_Click(object sender, RoutedEventArgs e)
        {
            AddEditMovieDialog cd = new AddEditMovieDialog();
            cd.Title = "Tilføj ny film";

            if ((bool)cd.ShowDialog())
            {
                try
                {
                    mvm.AddMovie(cd.tbMovieTitle.Text, cd.tbMovieGenre.Text, cd.Minutes, cd.tbMovieDirector.Text, cd.dpMovieReleaseDate.SelectedDate.Value);
                }
                catch (NotImplementedException)
                {
                    MessageBox.Show("Denne funktionalitet er endnu ikke implementeret!", "Kan ikke tilføje film", MessageBoxButton.OK);
                }
                catch (Exception)
                {
                    MessageBox.Show($"Filmen {cd.tbMovieTitle} mm. eksisterer allerede. Prøv igen.", "Kan ikke tilføje film", MessageBoxButton.OK);
                }
            }
        }
        private void btnEditMovie_Click(object sender, RoutedEventArgs e)
        {
            if (mvm.SelectedMovie != null)
            {
                AddEditMovieDialog cd = new AddEditMovieDialog();
                cd.Title = "Redigér film";
                cd.tbMovieTitle.Text = mvm.SelectedMovie.Title;
                cd.tbMovieGenre.Text = mvm.SelectedMovie.Genre;
                cd.tbMovieDuration.Text = mvm.SelectedMovie.Duration.ToString();
                cd.tbMovieDirector.Text = mvm.SelectedMovie.Director;
                cd.dpMovieReleaseDate.SelectedDate = mvm.SelectedMovie.ReleaseDate;

                if ((bool)cd.ShowDialog())
                {
                    if (mvm.SelectedMovie.Title != cd.tbMovieTitle.Text || 
                        mvm.SelectedMovie.Genre != cd.tbMovieGenre.Text || 
                        mvm.SelectedMovie.Duration != cd.Minutes || 
                        mvm.SelectedMovie.Director != cd.tbMovieDirector.Text || 
                        mvm.SelectedMovie.ReleaseDate != cd.dpMovieReleaseDate.SelectedDate.Value)
                    {
                        mvm.UpdateMovie(mvm.SelectedMovie, cd.tbMovieTitle.Text, cd.tbMovieGenre.Text, cd.Minutes, cd.tbMovieDirector.Text, cd.dpMovieReleaseDate.SelectedDate.Value);
                    }
                }
            }
            else
            {
                MessageBox.Show($"Ingen film er valgt. Vælg først en.", "Kan ikke redigere film", MessageBoxButton.OK);
            }
        }
        private void btnDeleteMovie_Click(object sender, RoutedEventArgs e)
        {
            if (mvm.SelectedMovie != null)
            {
                MessageBoxResult answer = MessageBox.Show($"Er du sikker på, at du vil slette filmen {mvm.SelectedMovie.Title}?", "Slet film", MessageBoxButton.YesNo);

                if (answer == MessageBoxResult.Yes)
                {
                    mvm.DeleteMovie(mvm.SelectedMovie);
                }
            }
            else
            {
                MessageBox.Show($"Ingen film er valgt. Vælg først en.", "Kan ikke slette film", MessageBoxButton.OK);
            }
        }
        private void btnLockReleaseMovie_Click(object sender, RoutedEventArgs e)
        {
            if (mvm.LockedMovie == null)
            {
                if (lbMovies.SelectedItem != null)
                {
                    mvm.LockedMovie = (MovieVM)lbMovies.SelectedItem;
                    btnMovieLockRelease.Content = "Frigiv";
                    mvm.RefreshVMs();
                }
                else
                {
                    MessageBox.Show($"Ingen film er valgt. Vælg først en.", "Lås film", MessageBoxButton.OK);
                }
            }
            else
            {
                mvm.LockedMovie = null;
                btnMovieLockRelease.Content = "Lås";
                mvm.RefreshVMs();
            }
        }

        private void btnAddShow_Click(object sender, RoutedEventArgs e)
        {
            AddEditShowDialog cd = new AddEditShowDialog();
            cd.Title = "Tilføj ny forestilling";

            if ((bool)cd.ShowDialog())
            {
                try
                {
                    mvm.AddShow(cd.ShowDateTime);
                }
                catch (NotImplementedException)
                {
                    MessageBox.Show("Denne funktionalitet er endnu ikke implementeret!", "Kan ikke tilføje forestilling", MessageBoxButton.OK);
                }
                catch (Exception)
                {
                    MessageBox.Show($"Forestillingen {cd.ShowDateTime} eksisterer allerede. Prøv igen.", "Kan ikke tilføje forestilling", MessageBoxButton.OK);
                }
            }
        }
        private void btnEditShow_Click(object sender, RoutedEventArgs e)
        {
            if (mvm.SelectedShow != null)
            {
                AddEditShowDialog cd = new AddEditShowDialog();
                cd.Title = "Redigér forestilling";
                cd.dpShowDate.SelectedDate = mvm.SelectedShow.ShowDateTime;
                cd.tbShowTime.Text = $"{mvm.SelectedShow.ShowDateTime.Hour}:{mvm.SelectedShow.ShowDateTime.Minute}";

                if ((bool)cd.ShowDialog())
                {
                    if (mvm.SelectedShow.ShowDateTime != cd.ShowDateTime)
                    {
                        mvm.UpdateShow(mvm.SelectedShow, cd.ShowDateTime);
                    }
                }
            }
            else
            {
                MessageBox.Show($"Ingen forestilling er valgt. Vælg først en.", "Kan ikke redigere forestilling", MessageBoxButton.OK);
            }
        }
        private void btnDeleteShow_Click(object sender, RoutedEventArgs e)
        {
            if (mvm.SelectedShow != null)
            {
                MessageBoxResult answer = MessageBox.Show($"Er du sikker på, at du vil slette forestillingen {mvm.SelectedShow.ShowDateTime}?", "Slet forestilling", MessageBoxButton.YesNo);

                if (answer == MessageBoxResult.Yes)
                {
                    mvm.DeleteShow(mvm.SelectedShow);
                }
            }
            else
            {
                MessageBox.Show($"Ingen forestilling er valgt. Vælg først en.", "Kan ikke slette forestilling", MessageBoxButton.OK);
            }
        }
        private void btnLockReleaseShow_Click(object sender, RoutedEventArgs e)
        {
            if (mvm.LockedShow == null)
            {
                if (lbShows.SelectedItem != null)
                {
                    mvm.LockedShow = (ShowVM)lbShows.SelectedItem;
                    btnShowLockRelease.Content = "Frigiv";
                    mvm.RefreshVMs();
                }
                else
                {
                    MessageBox.Show($"Ingen forestilling er valgt. Vælg først en.", "Lås forestilling", MessageBoxButton.OK);
                }
            }
            else
            {
                mvm.LockedShow = null;
                btnShowLockRelease.Content = "Lås";
                mvm.RefreshVMs();
            }
        }

        private void btnAddBooking_Click(object sender, RoutedEventArgs e)
        {
            AddEditBookingDialog cd = new AddEditBookingDialog();
            cd.Title = "Tilføj ny booking";

            if ((bool)cd.ShowDialog())
            {
                try
                {
                    mvm.AddBooking(cd.tbBookingMail.Text, cd.tbBookingPhone.Text);
                }
                catch (NotImplementedException)
                {
                    MessageBox.Show("Denne funktionalitet er endnu ikke implementeret!", "Kan ikke tilføje booking", MessageBoxButton.OK);
                }
                catch (Exception)
                {
                    MessageBox.Show($"Bookingen {cd.tbBookingMail.Text} ({cd.tbBookingPhone.Text}) eksisterer allerede. Prøv igen.", "Kan ikke tilføje booking", MessageBoxButton.OK);
                }
            }

        }
        private void btnEditBooking_Click(object sender, RoutedEventArgs e)
        {
            if (mvm.SelectedBooking != null)
            {
                AddEditBookingDialog cd = new AddEditBookingDialog();
                cd.Title = "Redigér booking";
                cd.tbBookingMail.Text = mvm.SelectedBooking.BookingMail;
                cd.tbBookingPhone.Text = mvm.SelectedBooking.BookingPhone;

                if ((bool)cd.ShowDialog())
                {
                    if (mvm.SelectedBooking.BookingMail != cd.tbBookingMail.Text || mvm.SelectedBooking.BookingPhone != cd.tbBookingPhone.Text)
                    {
                        mvm.UpdateBooking(mvm.SelectedBooking, cd.tbBookingMail.Text, cd.tbBookingPhone.Text);
                    }
                }
            }
            else
            {
                MessageBox.Show($"Ingen booking er valgt. Vælg først en.", "Kan ikke redigere booking", MessageBoxButton.OK);
            }
        }
        private void btnDeleteBooking_Click(object sender, RoutedEventArgs e)
        {
            if (mvm.SelectedBooking != null)
            {
                MessageBoxResult answer = MessageBox.Show($"Er du sikker på, at du vil slette bookingen {mvm.SelectedBooking.BookingMail} ({mvm.SelectedBooking.BookingPhone})?", "Slet booking", MessageBoxButton.YesNo);

                if (answer == MessageBoxResult.Yes)
                {
                    mvm.DeleteBooking(mvm.SelectedBooking);
                }
            }
            else
            {
                MessageBox.Show($"Ingen booking er valgt. Vælg først en.", "Kan ikke slette booking", MessageBoxButton.OK);
            }
        }
        private void btnLockReleaseBooking_Click(object sender, RoutedEventArgs e)
        {
            //if (mvm.SelectedBooking != null)
            //    mvm.SelectedBooking = null;

            if (mvm.LockedBooking == null)
            {
                if (lbBookings.SelectedItem != null)
                {
                    mvm.LockedBooking = (BookingVM)lbBookings.SelectedItem;
                    btnBookingLockRelease.Content = "Frigiv";
                    mvm.RefreshVMs();
                }
                else
                {
                    MessageBox.Show($"Ingen booking er valgt. Vælg først en.", "Lås booking", MessageBoxButton.OK);
                }
            }
            else
            {
                mvm.LockedBooking = null;
                btnBookingLockRelease.Content = "Lås";
                mvm.RefreshVMs();
            }
        }
    }
}
