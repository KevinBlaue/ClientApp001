using De.HsFlensburg.ClientApp001.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace De.HsFlensburg.ClientApp001.Logic.Ui.ViewModels
{
    public class StatistikWindowViewModel : INotifyPropertyChanged
    {

        public BookCollectionViewModel MyList { get; set; }
        public ICommand CreateStatistics { get; }
        //data bindings to update the content in the view when the data is changed here line 17 to 213
        private int allPages;
        public int AllPages
        {
            get
            {
                return allPages;
            }
            set
            {
                allPages = value;
                OnPropertyChanged(nameof(AllPages));
            }
        }

        private int medianPages;
        public int MedianPages
        {
            get
            {
                return medianPages;
            }
            set
            {
                medianPages = value;
                OnPropertyChanged(nameof(MedianPages));
            }
        }

        private string longestBook;
        public string LongestBook
        {
            get
            {
                return longestBook;
            }
            set
            {
                longestBook = value;
                OnPropertyChanged(nameof(LongestBook));
            }
        }

        private string shortestBook;
        public string ShortestBook
        {
            get
            {
                return shortestBook;
            }
            set
            {
                shortestBook = value;
                OnPropertyChanged(nameof(ShortestBook));
            }
        }

        private int allAuthors;
        public int AllAuthors
        {
            get
            {
                return allAuthors;
            }
            set
            {
                allAuthors = value;
                OnPropertyChanged(nameof(AllAuthors));
            }
        }

        private string mostAuthor;
        public string MostAuthor
        {
            get
            {
                return mostAuthor;
            }
            set
            {
                mostAuthor = value;
                OnPropertyChanged(nameof(MostAuthor));
            }
        }

        private int medianRelease;
        public int MedianRelease
        {
            get
            {
                return medianRelease;
            }
            set
            {
                medianRelease = value;
                OnPropertyChanged(nameof(MedianRelease));
            }
        }

        private string oldestBook;
        public string OldestBook
        {
            get
            {
                return oldestBook;
            }
            set
            {
                oldestBook = value;
                OnPropertyChanged(nameof(OldestBook));
            }
        }

        private double medianPrice;
        public double MedianPrice
        {
            get
            {
                return medianPrice;
            }
            set
            {
                medianPrice = value;
                OnPropertyChanged(nameof(MedianPrice));
            }
        }

        private double priceOfAll;
        public double PriceOfAll
        {
            get
            {
                return priceOfAll;
            }
            set
            {
                priceOfAll = value;
                OnPropertyChanged(nameof(PriceOfAll));
            }
        }

        private string mostExpensivBook;
        public string MostExpensivBook
        {
            get
            {
                return mostExpensivBook;
            }
            set
            {
                mostExpensivBook = value;
                OnPropertyChanged(nameof(MostExpensivBook));
            }
        }


        private string leastExpensivBook;
        public string LeastExpensivBook
        {
            get
            {
                return leastExpensivBook;
            }
            set
            {
                leastExpensivBook = value;
                OnPropertyChanged(nameof(LeastExpensivBook));
            }
        }

        private int allPublisher;
        public int AllPublisher
        {
            get
            {
                return allPublisher;
            }
            set
            {
                allPublisher = value;
                OnPropertyChanged(nameof(AllPublisher));
            }
        }

        private string mostPublisher;
        public string MostPublisher
        {
            get
            {
                return mostPublisher;
            }
            set
            {
                mostPublisher = value;
                OnPropertyChanged(nameof(MostPublisher));
            }
        }


        public StatistikWindowViewModel(BookCollectionViewModel viewModelCollection)
        {
            MyList = viewModelCollection;
            CreateStatistics = new RelayCommand(CreateStatisticsModel);

        }

        private void CreateStatisticsModel()
        {
            //Create all arrays to store the all the diffrent data sets
            int arrayLength = MyList.Count;
            String[] titel = new String[arrayLength];
            String[] autors = new String[arrayLength];
            int[] pages = new int[arrayLength];
            String[] releasYear = new String[arrayLength];
            double[] price = new double[arrayLength];
            String[] publisher = new String[arrayLength];
            var i = 0;
            foreach (var bvm in MyList)
            {
                //get all the data from each list entry an store it in the corresponding array
                titel[i] = bvm.Title;
                pages[i] = bvm.Sites;
                autors[i] = bvm.Author;
                releasYear[i] = bvm.Year;
                price[i] = bvm.Price;
                publisher[i] = bvm.Publisher;
                i++;
            }
            //call all methods to create the statistics
            pageStatistics(pages, titel);
            authorStatistics(autors);
            releaseStatistics(releasYear, titel);
            priceStatistics(price, titel);
            publisherStatistics(publisher, titel);
        }

        private void pageStatistics(int[] pages, String[] titel)
        {
            int totalPages = 0;
            int mostPages = 0;
            int leastPages = 0;
            var longestBookIndex = 0;
            var shortestBookIndex = 0;
            var i = 0;
            //Going through the array wich contains all page lenghts of every book
            //Calculates the combined number of Pages, the Longest book and the shortest book
            foreach (var pageCount in pages)
            {
                totalPages += pageCount;

                if (pageCount > mostPages)
                {
                    mostPages = pageCount;
                    longestBookIndex = i;
                }
                if (pageCount < leastPages || i == 0)
                {
                    leastPages = pageCount;
                    shortestBookIndex = i;
                }
                i++;
            }
            //updates the data bindings so the changes are seen in the view
            AllPages = totalPages;
            MedianPages = totalPages / pages.Length;
            LongestBook = titel[longestBookIndex] + " with: " + mostPages.ToString() + " total pages";
            ShortestBook = titel[shortestBookIndex] + " with: " + leastPages.ToString() + " total pages";
        }

        private void authorStatistics(String[] authorsArray)
        {
            String[] numberOfAuthors = new String[authorsArray.Length];
            var i = 0;
            var counter = 0;
            var mostCounter = 0;
            var freqAuthor = "";
            bool isDouble = false;
            //Checks every books author and counts the number of unique authors 
            foreach (var author in authorsArray)
            {
                foreach (var doubelAuthor in numberOfAuthors)
                {
                    if (author == doubelAuthor)
                    {
                        isDouble = true;
                        break;
                    }
                    else if (doubelAuthor == null)
                    {
                        break;
                    }
                }

                if (isDouble == false)
                {
                    numberOfAuthors[i++] = author;
                }
                isDouble = false;
            }
            
            //Goes through every books author and counts how many books one author has written and
            //stors the one with the most books
            foreach (var author in authorsArray)
            {
                foreach (var authorToCompare in authorsArray)
                {
                    if (author == authorToCompare)
                    {
                        counter++;
                    }
                }
                if (counter > mostCounter)
                {
                    mostCounter = counter;
                    freqAuthor = author;
                }
                counter = 0;
            }

            //updates the data bindings so the changes are seen in the view
            AllAuthors = i;
            MostAuthor = freqAuthor + " with: " + mostCounter.ToString() + " books to his name";
        }

        private void releaseStatistics(String[] years, String[] titel)
        {
            var i = 0;
            var yearAsInt = 0;
            var median = 0;
            var oldestYear = 0;
            var oldestIndex = 0;
            //Goes through every books release year and checks wich is the oldest
            //also counts all years together to caculate the median release Year
            foreach (var year in years)
            {
                yearAsInt = Int32.Parse(year);
                median += yearAsInt;
                if (yearAsInt < oldestYear || i == 0)
                {
                    oldestYear = yearAsInt;
                    oldestIndex = i;
                }
                i++;
            }

            //updates the data bindings so the changes are seen in the view
            MedianRelease = median / i;
            OldestBook = titel[oldestIndex] + " released: " + oldestYear;
        }

        private void priceStatistics(double[] prices, String[] titel)
        {
            int i = 0;
            double totalPrice = 0.0;
            var median = 0;
            double mostExpensiv = 0;
            var mostIndex = 0;
            double leastExpensiv = 0;
            var leastIndex = 0;
            //Goes through every books price and checks wich is the most and least expensive
            //also calculates the total cost of all the books Prices Combined
            foreach (var price in prices)
            {
                totalPrice += price;
                if (price > mostExpensiv)
                {
                    mostExpensiv = price;
                    mostIndex = i;
                }
                if (price < leastExpensiv || i == 0)
                {
                    leastExpensiv = price;
                    leastIndex = i;
                }
                i++;
            }

            //updates the data bindings so the changes are seen in the view
            MedianPrice = Math.Round(totalPrice / i, 2);
            PriceOfAll = totalPrice;
            MostExpensivBook = titel[mostIndex] + " with a price of : " + mostExpensiv;
            LeastExpensivBook = titel[leastIndex] + " with a price of : " + leastExpensiv;
        }

        private void publisherStatistics(String[] publisherArray, String[] titel)
        {

            String[] numberOfPublisher = new String[publisherArray.Length];
            int i = 0;
            bool isDouble = false;
            int counter = 0;
            int mostCounter = 0;
            string freqPublisher = "";

            //Checks every books publisher and counts the number of unique publishers 
            foreach (var publisher in publisherArray)
            {
                foreach (var doubelPublisher in numberOfPublisher)
                {
                    if (publisher == doubelPublisher)
                    {
                        isDouble = true;
                        break;
                    }
                    else if (doubelPublisher == null)
                    {
                        break;
                    }
                }

                if (isDouble == false)
                {
                    numberOfPublisher[i++] = publisher;
                }
                isDouble = false;
            }

            //Goes through every books publisher and counts how many books one publisher has published and
            //stors the one with the most books
            foreach (var publisher in publisherArray)
            {
                foreach (var publisherToCompare in publisherArray)
                {
                    if (publisher == publisherToCompare)
                    {
                        counter++;
                    }
                }
                if (counter > mostCounter)
                {
                    mostCounter = counter;
                    freqPublisher = publisher;
                }
                counter = 0;
            }

            //updates the data bindings so the changes are seen in the view
            AllPublisher = i;
            MostPublisher = freqPublisher + " has the most books published with : " + mostCounter.ToString() + " books";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
