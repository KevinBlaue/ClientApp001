using De.HsFlensburg.ClientApp001.Logic.Ui.ViewModels;
using De.HsFlensburg.ClientApp001.Logic.Ui.Wrapper;

namespace De.HsFlensburg.ClientApp001.Logic.Ui
{
    public class ViewModelLocator
    {
        public BookCollectionViewModel TheBookCollectionViewModel { get; set; }
        public MainWindowViewModel TheMainWindowViewModel { get; set; }
        public NewBookWindowViewModel TheNewBookWindowViewModel { get; set; }
        public EditBookWindowViewModel TheEditBookWindowViewModel { get; set; }
        public StatistikWindowViewModel TheStatistikWindowViewModel { get; set; }
        public ImportExportWindowViewModel TheImportExportWindowViewModel { get; set; }
        public PrintWindowViewModel ThePrintWindowViewModel { get; }

        public ViewModelLocator()
        {
            TheBookCollectionViewModel = new BookCollectionViewModel();
            TheMainWindowViewModel = new MainWindowViewModel(TheBookCollectionViewModel);
            TheNewBookWindowViewModel = new NewBookWindowViewModel(TheBookCollectionViewModel);
            TheEditBookWindowViewModel = new EditBookWindowViewModel();
            TheStatistikWindowViewModel = new StatistikWindowViewModel(TheBookCollectionViewModel);
            TheImportExportWindowViewModel = new ImportExportWindowViewModel(TheBookCollectionViewModel);
            ThePrintWindowViewModel = new PrintWindowViewModel(TheBookCollectionViewModel);
        }
    }
}