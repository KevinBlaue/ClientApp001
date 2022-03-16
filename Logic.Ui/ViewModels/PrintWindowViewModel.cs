using De.HsFlensburg.ClientApp001.Logic.Ui.Wrapper;
using Services.PrintService;
using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace De.HsFlensburg.ClientApp001.Logic.Ui.ViewModels
{
    public class PrintWindowViewModel
    {
        public BookCollectionViewModel BookList { get; set; }
        public BookCollectionViewModel SelectedBooks { get; set; }
        public ICommand PrintBooks { get; }
        public ICommand CloseWindow { get; }
        public ICommand AddSelectedBookToCollection { get; }
        public ICommand RemoveSelectedBookToCollection { get; }

        public PrintWindowViewModel(BookCollectionViewModel bookCollection)
        {
            BookList = bookCollection;
            SelectedBooks = new BookCollectionViewModel();
            PrintBooks = new RelayCommand(PrintBooksCommand);
            CloseWindow = new RelayCommand(param => CloseWindowCommand(param));
            AddSelectedBookToCollection = new RelayCommand(param => AddSelectedBookToCollectionCommand(param));
            RemoveSelectedBookToCollection = new RelayCommand(param => RemoveSelectedBookToCollectionCommand(param));
        }

        private void RemoveSelectedBookToCollectionCommand(object param)
        {
            IList items = (IList)param;
            var collection = items.Cast<BookViewModel>();

            foreach (BookViewModel book in collection)
            {
                SelectedBooks.Remove(book);
            }
        }

        private void AddSelectedBookToCollectionCommand(object param)
        {
            IList items = (IList)param;
            var collection = items.Cast<BookViewModel>();

            foreach (BookViewModel book in collection)
            {
                if (!CheckItemIsInSelected(book))
                {
                    SelectedBooks.Add(book);
                }
            }
        }

        private bool CheckItemIsInSelected(BookViewModel currentBook)
        {
            foreach (BookViewModel book in SelectedBooks)
            {
                if (book.Equals(currentBook))
                {
                    return true;
                }
            }
            return false;
        }

        private void CloseWindowCommand(object param)
        {
            SelectedBooks.Clear();
            Window window = (Window)param;
            window.Close();
        }

        private void PrintBooksCommand()
        {
            if (SelectedBooks.Count > 0)
            {
                PrintBookService printer = new PrintBookService(SelectedBooks.Model);
                printer.Printing();
            }
        }
    }
}
