using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace De.HsFlensburg.ClientApp001.Business.Model.BusinessObjects
{
    [Serializable]
    public class BookCollection: ObservableCollection<Book>
    {
    }
}