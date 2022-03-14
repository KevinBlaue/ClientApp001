using De.HsFlensburg.ClientApp001.Logic.Ui.Wrapper;
using Services.HtmlService;
using Services.XmlService;
using System;
using System.ComponentModel;

namespace De.HsFlensburg.ClientApp001.Logic.Ui.ViewModels
{
    public class ExportWindowViewModel : INotifyPropertyChanged
    {
        private BookCollectionViewModel bookCollection;
        private bool success;
        private string status;
        private string typ;

        public ExportWindowViewModel(BookCollectionViewModel viewModelCollection)
        {
            ExportToXmlCommand = new RelayCommand(ExportToXmlMethod);
            ExportToHtmlCommand = new RelayCommand(ExportToHtmlMethod);
            Books = viewModelCollection;
        }
        public BookCollectionViewModel Books
        {
            get
            {
                return bookCollection;
            }
            set
            {
                bookCollection = value;
                OnPropertyChanged("BookCollection");
            }
        }
        public bool Success
        {
            get
            {
                return success;
            }
            set
            {
                if (value)
                {
                    Status = $"- {Typ} - Export erfolgreich -";
                }
                else
                {
                    Status = $"- {Typ} - Fehler beim Export -";
                }
                success = value;
                OnPropertyChanged("Success");
            }
        }
        public string Typ
        {
            get
            {
                return typ;
            }
            set
            {
                typ = value;
                OnPropertyChanged("Typ");
            }
        }
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }
        public RelayCommand ExportToXmlCommand { get; }
        public RelayCommand ExportToHtmlCommand { get; }
        private async void ExportToXmlMethod()
        {
            XmlBuilder xmlBuilder = new XmlBuilder();
            Typ = "XML";
            Success = await xmlBuilder.ExportXmlTextToFile(Books.Model);
        }
        private async void ExportToHtmlMethod()
        {
            HtmlBuilder htmlBuilder = new HtmlBuilder();
            Typ = "HTML";
            Success = await htmlBuilder.ExportToHtmlFile(Books.Model);
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
