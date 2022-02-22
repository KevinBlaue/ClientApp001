using System;
using System.Windows.Input;
using De.HsFlensburg.ClientApp001.Logic.Ui.Wrapper;

namespace De.HsFlensburg.ClientApp001.Logic.Ui.ViewModels
{
    public class NewClientWindowViewModel
    {
        public int Identifier { get; set; }
        public string Name { get; set; }
        private ClientCollectionViewModel clientCollectionViewModel;
        public ICommand AddClient { get; }

        public NewClientWindowViewModel(ClientCollectionViewModel viewModelCollection)
        {
            AddClient = new RelayCommand(AddClientMethod);
            clientCollectionViewModel = viewModelCollection;
        }
        
        private void AddClientMethod()
        {
            ClientViewModel cvm = new ClientViewModel();
            cvm.Id = Identifier;
            cvm.Name = Name;
            clientCollectionViewModel.Add(cvm);
        }
    }
}