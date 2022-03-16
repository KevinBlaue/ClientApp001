using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using De.HsFlensburg.ClientApp001.Logic.Ui.Wrapper;

namespace De.HsFlensburg.ClientApp001.Logic.Ui.ViewModels
{
    public class SearchBookWindowViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Year { get; set; }
        public string Publisher { get; set; }
        public int Sites { get; set; }
        public string Genre { get; set; }

        public BookCollectionViewModel FoundBooks { get; set; }

        private BookCollectionViewModel bookCollectionViewModel;
        public ICommand SearchBookCommand { get; }

        public SearchBookWindowViewModel(BookCollectionViewModel viewModelCollection)
        {
            SearchBookCommand = new RelayCommand(SearchBookMethod);
            FoundBooks = new BookCollectionViewModel();
            bookCollectionViewModel = viewModelCollection;
        }

        private void SearchBookMethod()
        {
            FoundBooks.Clear();

            if (Title != null)
            {
                SearchMethod("Title" ,Title);
            }
            else if(Author != null)
            {
                SearchMethod("Author" ,Author);
            }
            else if (Year != null)
            {
                SearchMethod("Year", Year);
            }
            else if (Publisher != null)
            {
                SearchMethod("Publisher", Publisher);
            }
            else if (Genre != null)
            {
                SearchMethod("Genre", Genre);
            }         
            else
            {
                Console.WriteLine("Book not found");
            }

        }

        private void SearchMethod(string property, string search)
        {
            if(property == "Title")
            {
                foreach (BookViewModel book in bookCollectionViewModel)
                {
                    if (book.Title == search)
                    {
                        FoundBooks.Add(book);
                    }
                }
            }
            else if (property == "Author")
            {
                foreach (BookViewModel book in bookCollectionViewModel)
                {
                    if (book.Author == search)
                    {
                        FoundBooks.Add(book);
                    }
                }
            }else if (property == "Year")
                {
                    foreach (BookViewModel book in bookCollectionViewModel)
                    {
                        if (book.Year == search)
                        {
                            FoundBooks.Add(book);
                        }
                    }
                }
            else if (property == "Publisher")
            {
                foreach (BookViewModel book in bookCollectionViewModel)
                {
                    if (book.Publisher == search)
                    {
                        FoundBooks.Add(book);
                    }
                }
            }
            else if (property == "Sites")
            {
                foreach (BookViewModel book in bookCollectionViewModel)
                {
                    if (book.Sites == int.Parse(search))
                    {
                        FoundBooks.Add(book);
                    }
                }
            }
            else if (property == "Genre")
            {
                foreach (BookViewModel book in bookCollectionViewModel)
                {
                    if (book.Genre == search)
                    {
                        FoundBooks.Add(book);
                    }
                }
            }

        }
    }
}
