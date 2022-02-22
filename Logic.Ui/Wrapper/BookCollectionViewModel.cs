using System.Collections.Generic;
using System.ComponentModel;
using De.HsFlensburg.ClientApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp001.Logic.Ui.Base;

namespace De.HsFlensburg.ClientApp001.Logic.Ui.Wrapper
{
    public class BookCollectionViewModel :
        ViewModelSyncCollection<
            BookViewModel,
            Book,
            BookCollection>
    {
        public override void NewModelAssigned()
        {
            foreach (var bvm in this)
            {
                var modelPropChanged = bvm.Model as INotifyPropertyChanged;
                if (modelPropChanged != null)
                {
                    modelPropChanged.PropertyChanged += bvm.OnPropertyChangedInModel;
                }
            }
        }
    }
}