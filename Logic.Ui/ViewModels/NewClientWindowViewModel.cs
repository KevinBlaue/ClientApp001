using System;
using System.Windows.Input;
using De.HsFlensburg.ClientApp001.Logic.Ui.Wrapper;

namespace De.HsFlensburg.ClientApp001.Logic.Ui.ViewModels
{
    public class NewClientWindowViewModel
    {
        public int Identifier { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Year { get; set; }
        public string Publisher { get; set; }
        public int Sites { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
        
        private BookCollectionViewModel bookCollectionViewModel;
        public ICommand AddBookCommand { get; }

        public NewClientWindowViewModel(BookCollectionViewModel viewModelCollection)
        {
            AddBookCommand = new RelayCommand(AddBookMethod);
            bookCollectionViewModel = viewModelCollection;
        }
        
        private void AddBookMethod()
        {
            BookViewModel bvm = new BookViewModel();
            bvm.Id = Identifier;
            bvm.Title = Title;
            bvm.Author = Author;
            bvm.Year = Year;
            bvm.Publisher = Publisher;
            bvm.Sites = Sites;
            bvm.Genre = Genre;
            bvm.Price = Price;
            bookCollectionViewModel.Add(bvm);
        }
    }
}