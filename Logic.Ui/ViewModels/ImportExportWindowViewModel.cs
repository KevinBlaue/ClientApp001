using De.HsFlensburg.ClientApp001.Logic.Ui.Wrapper;
using Services.HtmlService;
using Services.XmlService;
using System;
using System.ComponentModel;

namespace De.HsFlensburg.ClientApp001.Logic.Ui.ViewModels
{
    public class ImportExportWindowViewModel : INotifyPropertyChanged
    {
        private BookCollectionViewModel bookCollection;
        private bool success;
        private string status;
        private string typ;

        public ImportExportWindowViewModel(BookCollectionViewModel viewModelCollection)
        {
            ExportToXmlCommand = new RelayCommand(ExportToXmlMethod);
            ExportToHtmlCommand = new RelayCommand(ExportToHtmlMethod);
            ImportXmlCommand = new RelayCommand(ImportXmlMethod);
            ImportHtmlCommand = new RelayCommand(ImportHtmlMethod);
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
                    Status = $"- {Typ} - erfolgreich -";
                }
                else
                {
                    Status = $"- {Typ} - Fehlerhaft -";
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
        public RelayCommand ImportXmlCommand { get; }
        public RelayCommand ImportHtmlCommand { get; }
        private void ExportToXmlMethod()
        {
            XmlExporter xmlExporter = new XmlExporter();
            Typ = "XML - Export";
            Success = xmlExporter.ExportXmlTextToFile(Books.Model);
        }
        private void ExportToHtmlMethod()
        {
            HtmlExporter htmlExporter = new HtmlExporter();
            Typ = "HTML - Export";
            Success = htmlExporter.ExportToHtmlFile(Books.Model);
        }
        private void ImportXmlMethod()
        {
            XmlImporter xmlImporter = new XmlImporter();
            Typ = "XML - Import";
            Success = xmlImporter.ImportXmlFileToBookCollection(Books.Model);
        }
        private void ImportHtmlMethod()
        {
            HtmlImporter htmlImporter = new HtmlImporter();
            Typ = "HTML - Import";
            Success = htmlImporter.ImportHtmlFileToBookCollection(Books.Model);
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
