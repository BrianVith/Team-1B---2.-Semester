using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TheMovies.Views
{
    /// <summary>
    /// Interaction logic for AddEditMovieDialog.xaml
    /// </summary>
    public partial class AddEditMovieDialog : Window
    {
        public int Minutes { get; set; }

        public AddEditMovieDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Minutes = TimeToMinutes(tbMovieDuration.Text);

            if (!string.IsNullOrEmpty(tbMovieTitle.Text) &&
                !string.IsNullOrEmpty(tbMovieGenre.Text) &&
                this.Minutes != default &&
                !string.IsNullOrEmpty(tbMovieDirector.Text) &&
                dpMovieReleaseDate.SelectedDate.HasValue)
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show($"Alle felter skal være udfyldt korrekt", "Film", MessageBoxButton.OK);
            }

        }

        private int TimeToMinutes(string time)
        {
            int result = default;

            try
            {
                if (time.Contains(':'))
                {
                    string[] splitTime = time.Split(':');
                    result = int.Parse(splitTime[0]) * 60 + int.Parse(splitTime[1]);
                }
                else
                {
                    result = int.Parse(time);
                }
            }
            catch (Exception)
            {
                // No action
            }

            return result;
        }
    }
}
