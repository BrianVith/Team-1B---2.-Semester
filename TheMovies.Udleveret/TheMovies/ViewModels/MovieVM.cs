using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TheMovies.Models;

namespace TheMovies.ViewModels
{
    public class MovieVM : INotifyPropertyChanged
    {
        private string title;
        public string Title
        {
            get { return title; }
            set 
            {
                if (value != title)
                {
                    title = value;
                    OnPropertyChanged("Title");
                }
            }
        }

        private string genre;
        public string Genre
        {
            get { return genre; }
            set 
            {
                if (value != genre)
                {
                    genre = value;
                    OnPropertyChanged("Genre");
                }
            }
        }

        private int duration;
        public int Duration
        {
            get { return duration; }
            set 
            {
                if (value != duration)
                {
                    duration = value;
                    OnPropertyChanged("Duration");
                }
            }
        }

        private string director;
        public string Director
        {
            get { return director; }
            set 
            {
                if (value != director)
                {
                    director = value;
                    OnPropertyChanged("Director");
                }
            }
        }

        private DateTime releaseDate;
        public DateTime ReleaseDate
        {
            get { return releaseDate; }
            set 
            {
                if (value != releaseDate)
                {
                    releaseDate = value;
                    OnPropertyChanged("ReleaseDate");
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
            return $"{Title} ({Duration} minutes, directed by {Director}, genres: {Genre})";
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
