using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TheMovies.Models;

namespace TheMovies.ViewModels
{
    public class CinemaVM : INotifyPropertyChanged
    {
        private string cinema;
        public string Cinema
        {
            get { return cinema; }
            set 
            { 
                if (value != cinema)
                {
                    cinema = value;
                    OnPropertyChanged("Cinema");
                }
            }
        }

        private string town;
        public string Town
        {
            get { return town; }
            set 
            { 
                if (value != town)
                {
                    town = value;
                    OnPropertyChanged("Town");
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
            return $"{Cinema}, {Town}";
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
