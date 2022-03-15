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

            private string allPublisher;
        public string AllPublisher
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


        public StatistikWindowViewModel(BookCollectionViewModel viewModelCollection)
        {
            MyList = viewModelCollection;
            CreateStatistics = new RelayCommand(CreateStatisticsModel);

        }

        private void CreateStatisticsModel()
        {
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
                titel[i] = bvm.Title;
                pages[i] = bvm.Sites;
                autors[i] = bvm.Author;
                releasYear[i] = bvm.Year;
                price[i] = bvm.Price;
                publisher[i] = bvm.Publisher;
                i++;
            }
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
            AllPages = totalPages;
            MedianPages = totalPages / pages.Length;
            LongestBook = "Längstes Buch:" + titel[longestBookIndex] + " mit:" + mostPages.ToString() + " Seiten";
            ShortestBook = "Kürzestes Buch:" + titel[shortestBookIndex] + " mit:" + leastPages.ToString() + " Seiten";
        }

        private void authorStatistics(String[] authorsArray)
        {
            String[] numberOfAuthors = new String[authorsArray.Length];
            var i = 0;
            var j = 0;
            var counter = 0;
            var mostCounter = 0;
            var freqAuthor = "";
            bool isDouble = false;
            foreach (var author in authorsArray)
            {
                foreach (var doubelAuthor in numberOfAuthors)
                {
                    if (author == doubelAuthor)
                    {
                        isDouble = true;
                        break;
                    }
                }

                if (isDouble == false)
                {
                    numberOfAuthors[i++] = author;
                }
                isDouble = false;
            }


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

            AllAuthors = i;
            MostAuthor = freqAuthor + " has the most books with: " + mostCounter.ToString() + " books";
        }

        private void releaseStatistics(String[] years, String[] titel)
        {
            var i = 0;
            var yearAsInt = 0;
            var median = 0;
            var oldestYear = 0;
            var oldestIndex = 0;
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

            MedianRelease = median / i;
            OldestBook = titel[oldestIndex] + " release: " + oldestYear;
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

            MedianPrice = Math.Round(totalPrice / i, 2);
            PriceOfAll = totalPrice;
            MostExpensivBook = titel[mostIndex] + " is the most expensiv with a cost of: " + mostExpensiv;
            LeastExpensivBook = titel[leastIndex] + " is the least expensiv with a cost of: " + leastExpensiv;
        }

        private void publisherStatistics(String[] publisher, String[] titel)
        {



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
