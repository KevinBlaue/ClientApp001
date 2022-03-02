using De.HsFlensburg.ClientApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp001.Logic.Ui.Base;

namespace De.HsFlensburg.ClientApp001.Logic.Ui.Wrapper
{
    public class BookViewModel: ViewModelBase<Book>
    {
        public int Id
        {
            get
            {
                return Model.Id;
            }
            set
            {
                Model.Id = value;
            }
        }

        public string Title
        {
            get
            {
                return Model.Title;
            }
            set
            {
                Model.Title = value;
            }
        }

        public string Author
        {
            get
            {
                return Model.Author;
            }
            set
            {
                Model.Author = value;
            }
        }

        public string Year
        {
            get
            {
                return Model.Year;
            }
            set
            {
                Model.Year = value;
            }
        }

        public string Publisher
        {
            get
            {
                return Model.Publisher;
            }
            set
            {
                Model.Publisher = value;
            }
        }

        public int Sites
        {
            get
            {
                return Model.Sites;
            }
            set
            {
                Model.Sites = value;
            }
        }
        
        public string Genre
        {
            get
            {
                return Model.Genre;
            }
            set
            {
                Model.Genre = value;
            }
        }

        public double Price
        {
            get
            {
                return Model.Price;
            }
            set
            {
                Model.Price = value;
            }
        }

        public override void NewModelAssigned()
        {
            throw new System.NotImplementedException();
        }
    }
}