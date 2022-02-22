using De.HsFlensburg.ClientApp001.Logic.Ui.ViewModels;
using De.HsFlensburg.ClientApp001.Logic.Ui.Wrapper;

namespace De.HsFlensburg.ClientApp001.Logic.Ui
{
    public class ViewModelLocator
    {
        public ClientCollectionViewModel TheClientCollectionViewModel { get; set; }
        public MainWindowViewModel TheMainWindowViewModel { get; set; }
        public NewClientWindowViewModel TheNewClientWindowViewModel { get; set; }

        public ViewModelLocator()
        {
            TheClientCollectionViewModel = new ClientCollectionViewModel();
            TheMainWindowViewModel = new MainWindowViewModel(TheClientCollectionViewModel);
            TheNewClientWindowViewModel = new NewClientWindowViewModel(TheClientCollectionViewModel);
        }
    }
}