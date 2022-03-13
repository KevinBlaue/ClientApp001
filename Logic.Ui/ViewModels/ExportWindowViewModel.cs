using De.HsFlensburg.ClientApp001.Logic.Ui.Wrapper;
using Services.XmlService;
using System.ComponentModel;

namespace De.HsFlensburg.ClientApp001.Logic.Ui.ViewModels
{
    public class ExportWindowViewModel : INotifyPropertyChanged
    {
        private BookCollectionViewModel bookCollection;
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
        public RelayCommand ExportToXmlCommand { get; }
        public ExportWindowViewModel(BookCollectionViewModel viewModelCollection)
        {
            ExportToXmlCommand = new RelayCommand(ExportToXmlMethod);
            Books = viewModelCollection;
        }
        private void ExportToXmlMethod()
        {
            XmlBuilder xmlBuilder = new XmlBuilder();
            xmlBuilder.ExportXmlTextToFile(Books.Model);
        }
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
