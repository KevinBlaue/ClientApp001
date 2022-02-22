using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using De.HsFlensburg.ClientApp001.Business.Model.Annotations;

namespace De.HsFlensburg.ClientApp001.Business.Model.BusinessObjects
{
    [Serializable]
    public class Book : INotifyPropertyChanged
    {
        private int id;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private string title;

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        
        private string author;

        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
                OnPropertyChanged("Author");
            }
        }
        
        private string year;

        public string Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }
        
        private string publisher;

        public string Publisher
        {
            get
            {
                return publisher;
            }
            set
            {
                publisher = value;
                OnPropertyChanged("Publisher");
            }
        }
        
        private int sites;

        public int Sites
        {
            get
            {
                return sites;
            }
            set
            {
                sites = value;
                OnPropertyChanged("Sites");
            }
        }
        
        private string genre;

        public string Genre
        {
            get
            {
                return genre;
            }
            set
            {
                genre = value;
                OnPropertyChanged("Genre");
            }
        }
        
        private double price;

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }
        
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}