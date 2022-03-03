using De.HsFlensburg.ClientApp001.Logic.Ui.Wrapper;
using System;
using System.ComponentModel;
using System.Windows;
using De.HsFlensburg.ClientApp001.Service.MessageBusWithParameter;

namespace De.HsFlensburg.ClientApp001.Logic.Ui.ViewModels
{
    public class EditBookWindowViewModel : INotifyPropertyChanged
    {
        private BookViewModel myBook;
        public BookViewModel MyBook
        {
            get
            {
                return myBook;
            }
            set
            {
                myBook = value;
                OnPropertyChanged("SelectedBook");
            }
        }
        public RelayCommand EditBook { get; }

        public EditBookWindowViewModel()
        {
            EditBook = new RelayCommand(param => SaveAndCloseWindow(param));
            Messenger.Instance.Register<BookViewModel>(this, Notify);
        }

        public void Notify(BookViewModel selectedBook)
        {
            MyBook = selectedBook;
        }

        private void SaveAndCloseWindow(object param)
        {
            Window window = (Window)param;
            window.Close();
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