using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TheMovies.Models;

namespace TheMovies.ViewModels
{
    public class BookingVM : INotifyPropertyChanged
    {
        private string bookingMail;
        public string BookingMail
        {
            get { return bookingMail; }
            set 
            {
                if (value != bookingMail)
                {
                    bookingMail = value;
                    OnPropertyChanged("BookingMail");
                }
            }
        }

        private string bookingPhone;
        public string BookingPhone
        {
            get { return bookingPhone; }
            set 
            {
                if (value != bookingPhone)
                {
                    bookingPhone = value;
                    OnPropertyChanged("BookingPhone");
                }
            }
        }

        private bool locked;
        public bool Locked
        {
            get { return locked; }
            set
            {
                locked = value;
                OnPropertyChanged("Locked");
            }
        }

        public override string ToString()
        {
            return $"Booking: {BookingMail}, {BookingPhone}";
        }

        // Observer pattern for databinding
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
