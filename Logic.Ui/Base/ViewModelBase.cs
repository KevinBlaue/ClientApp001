using System;
using System.ComponentModel;

namespace De.HsFlensburg.ClientApp001.Logic.Ui.Base
{
    public abstract class ViewModelBase<TypeOfModel> : INotifyPropertyChanged,
        IViewModel<TypeOfModel> where TypeOfModel : new()
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private TypeOfModel model;
        public TypeOfModel Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
                try
                {
                    this.NewModelAssigned();
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e.Message);
                }

            }
        }
        public ViewModelBase(TypeOfModel modelObject)
        {
            this.Model = modelObject;
            var modelPropChanged = this.Model as INotifyPropertyChanged;
            if (modelPropChanged != null)
            {
                modelPropChanged.PropertyChanged += OnPropertyChangedInModel;
            }
        }
        public ViewModelBase()
        {
            this.Model = new TypeOfModel();
            var modelPropChanged = this.Model as INotifyPropertyChanged;
            if (modelPropChanged != null)
            {
                modelPropChanged.PropertyChanged += OnPropertyChangedInModel;
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public abstract void NewModelAssigned();

        internal void OnPropertyChangedInModel(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }
    }
}