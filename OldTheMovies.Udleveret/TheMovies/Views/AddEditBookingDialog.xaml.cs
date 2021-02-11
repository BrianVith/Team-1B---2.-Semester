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
    /// Interaction logic for AddEditBookingDialog.xaml
    /// </summary>
    public partial class AddEditBookingDialog : Window
    {
        public AddEditBookingDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbBookingMail.Text) &&
                !string.IsNullOrEmpty(tbBookingPhone.Text))
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show($"Alle felter skal være udfyldt korrekt", "Booking", MessageBoxButton.OK);
            }
        }
    }
}
