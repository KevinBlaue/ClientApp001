using System.Collections.Generic;
using System.ComponentModel;
using De.HsFlensburg.ClientApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp001.Logic.Ui.Base;

namespace De.HsFlensburg.ClientApp001.Logic.Ui.Wrapper
{
    public class ClientCollectionViewModel :
        ViewModelSyncCollection<
            ClientViewModel,
            Client,
            ClientCollection>
    {
        public override void NewModelAssigned()
        {
            foreach (var cvm in this)
            {
                var modelPropChanged = cvm.Model as INotifyPropertyChanged;
                if (modelPropChanged != null)
                {
                    modelPropChanged.PropertyChanged += cvm.OnPropertyChangedInModel;
                }
            }
        }
    }
}