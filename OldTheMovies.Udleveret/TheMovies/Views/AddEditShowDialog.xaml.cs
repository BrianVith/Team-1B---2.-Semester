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
    /// Interaction logic for AddEditShowDialog.xaml
    /// </summary>
    public partial class AddEditShowDialog : Window
    {
        public DateTime ShowDateTime;

        public AddEditShowDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (DateTime.TryParse(dpShowDate.Text + " " + tbShowTime.Text, out ShowDateTime))
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show($"Alle felter skal være udfyldt korrekt", "Forestilling", MessageBoxButton.OK);
            }
        }
    }
}
