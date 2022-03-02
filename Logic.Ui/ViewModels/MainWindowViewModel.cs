using System;
using System.Windows.Input;
using De.HsFlensburg.ClientApp001.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp001.Service.MessageBus;
using De.HsFlensburg.ClientApp001.Service.MessageBus.MessageBusMessages;
using De.HsFlensburg.ClientApp001.Services.SerializationService;

namespace De.HsFlensburg.ClientApp001.Logic.Ui.ViewModels
{
    public class MainWindowViewModel
    {
        public ICommand DeleteSelectedModelCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand LoadCommand { get; }
        public ICommand OpenNewBookWindowCommand { get; }
        public BookCollectionViewModel MyList { get; set; }
        private ModelFileHandler modelFileHandler;
        private string pathForSerialization;
        public BookViewModel SelectedBook { get; set; }

        public MainWindowViewModel(BookCollectionViewModel viewModelCollection)
        {
            DeleteSelectedModelCommand = new RelayCommand(DeleteSelectedModelMethod);
            SaveCommand = new RelayCommand(SaveModel);
            LoadCommand = new RelayCommand(LoadModel);
            OpenNewBookWindowCommand = new RelayCommand(OpenNewBookWindowMethod);
            MyList = viewModelCollection;
            modelFileHandler = new ModelFileHandler();
            pathForSerialization = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                   "\\BookCollectionSerialization\\MyBooks.cc";
        }

        private void DeleteSelectedModelMethod()
        {
            if (SelectedBook != null)
            {
                 MyList.Remove(SelectedBook);
            }
        }

        private void SaveModel()
        {
            modelFileHandler.WriteModelToFile(pathForSerialization, MyList.Model);
        }

        private void LoadModel()
        {
            MyList.Model = modelFileHandler.ReadModelFromFile(pathForSerialization);
        }

        private void OpenNewBookWindowMethod()
        {
            ServiceBus.Instance.Send(new OpenNewBookWindowMessage());
        }
    }
}