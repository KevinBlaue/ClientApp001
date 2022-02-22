using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp001.Logic.Ui.Base
{
    public abstract class ViewModelSyncCollection
        <TypeViewModel, TypeModel, TypeModelCollection> :
        ObservableCollection<TypeViewModel>, IViewModel<TypeModelCollection>
        where TypeModelCollection : ObservableCollection<TypeModel>, new()
        where TypeModel : new()
        where TypeViewModel : class, IViewModel<TypeModel>, INotifyPropertyChanged, new()
    {
        private bool syncDisabled = false;
        private TypeModelCollection model;
        public TypeModelCollection Model
        {
            get
            {
                return model;
            }
            set
            {
                this.Clear();
                model = value;
                this.WrappListItems();
                this.NewModelAssigned();
                OnPropertyChanged("Model");
            }
        }
        private void WrappListItems()
        {
            syncDisabled = true;
            foreach (var element in model)
            {
                TypeViewModel wrapper = new TypeViewModel();
                wrapper.Model = element;
                this.Add(wrapper);
            }
            syncDisabled = false;
        }
        //protected abstract void SyncProperties(TypeModelCollection value);
        public ViewModelSyncCollection()
        {
            this.model = new TypeModelCollection();
            this.CollectionChanged += ViewModelCollectionChanged;
            model.CollectionChanged += ModelCollectionChanged;
        }
        public ViewModelSyncCollection(TypeModelCollection modelCollection)
        {
            this.model = modelCollection;
            this.CollectionChanged += ViewModelCollectionChanged;
            model.CollectionChanged += ModelCollectionChanged;
            this.WrappListItems();
        }
        private void ViewModelCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (syncDisabled) return;
            syncDisabled = true;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var model in e.NewItems.OfType<TypeViewModel>().Select(v => v.Model).OfType<TypeModel>())
                        Model.Add(model);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var model in e.OldItems.OfType<TypeViewModel>().Select(v => v.Model).OfType<TypeModel>())
                        Model.Remove(model);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Model.Clear();
                    break;
            }
            syncDisabled = false;
        }
        private void ModelCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (syncDisabled) return;
            syncDisabled = true;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var model in e.NewItems.OfType<TypeModel>())
                    {
                        var temp = new TypeViewModel();
                        temp.Model = model;
                        Add(temp);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var model in e.OldItems.OfType<TypeModel>())
                    {
                        Remove(GetViewModelOfModel(model));
                    }

                    break;
                case NotifyCollectionChangedAction.Reset:
                    this.Clear();
                    break;
            }
            syncDisabled = false;
        }
        private TypeViewModel GetViewModelOfModel(TypeModel client)
        {
            foreach (TypeViewModel cvm in this)
            {
                if (cvm.Model.Equals(client)) return cvm;
            }
            return null;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        public abstract void NewModelAssigned();
    }
}