using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TheMovies.Models;

namespace TheMovies.ViewModels
{
    public class ShowVM : INotifyPropertyChanged
    {
        private DateTime showDateTime;
        public DateTime ShowDateTime
        {
            get { return showDateTime; }
            set 
            { 
                if (value != showDateTime)
                {
                    showDateTime = value;
                    OnPropertyChanged("ShowDateTime");
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
            return $"Show time: {ShowDateTime}";
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
