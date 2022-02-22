using De.HsFlensburg.ClientApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp001.Logic.Ui.Base;

namespace De.HsFlensburg.ClientApp001.Logic.Ui.Wrapper
{
    public class ClientViewModel: ViewModelBase<Client>
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

        public string Name
        {
            get
            {
                return Model.Name;
            }
            set
            {
                Model.Name = value;
            }
        }

        public override void NewModelAssigned()
        {
            throw new System.NotImplementedException();
        }
    }
}