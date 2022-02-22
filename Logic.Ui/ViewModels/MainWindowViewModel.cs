using System;
using System.Linq;
using System.Windows.Input;
using De.HsFlensburg.ClientApp001.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp001.Service.MessageBus;
using De.HsFlensburg.ClientApp001.Service.MessageBus.MessageBusMessages;
using De.HsFlensburg.ClientApp001.Services.SerializationService;

namespace De.HsFlensburg.ClientApp001.Logic.Ui.ViewModels
{
    public class MainWindowViewModel
    {
        public ICommand RenameValueInModelCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand LoadCommand { get; }
        public ICommand OpenNewClientWindowCommand { get; }
        public ClientCollectionViewModel MyList { get; set; }
        private ModelFileHandler modelFileHandler;
        private string pathForSerialization;

        public MainWindowViewModel(ClientCollectionViewModel viewModelCollection)
        {
            RenameValueInModelCommand = new RelayCommand(RenameValueInModel);
            SaveCommand = new RelayCommand(SaveModel);
            LoadCommand = new RelayCommand(LoadModel);
            OpenNewClientWindowCommand = new RelayCommand(OpenNewClientWindowMethod);
            MyList = viewModelCollection;
            modelFileHandler = new ModelFileHandler();
            pathForSerialization = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                   "\\ClientCollectionSerialization\\MyClients.cc";
        }

        private void RenameValueInModel()
        {
            var first = MyList.FirstOrDefault();
            first.Model.Name = "Rename";
        }

        private void SaveModel()
        {
            modelFileHandler.WriteModelToFile(pathForSerialization, MyList.Model);
        }

        private void LoadModel()
        {
            MyList.Model = modelFileHandler.ReadModelFromFile(pathForSerialization);
        }

        private void OpenNewClientWindowMethod()
        {
            ServiceBus.Instance.Send(new OpenNewClientWindowMessage());
        }
    }
}