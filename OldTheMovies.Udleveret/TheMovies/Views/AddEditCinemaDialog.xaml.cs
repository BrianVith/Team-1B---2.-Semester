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
    /// Interaction logic for AddEditCinemaDialog.xaml
    /// </summary>

    public partial class AddEditCinemaDialog : Window
    {
        public AddEditCinemaDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbCinemaName.Text) &&
                !string.IsNullOrEmpty(tbCinemaTown.Text))
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show($"Alle felter skal være udfyldt", "Biograf", MessageBoxButton.OK);
            }
        }
    }
}
