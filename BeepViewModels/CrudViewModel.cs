using BeepEnterprize.Vis.Module;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Report;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.ViewModels
{
    public partial class CrudViewModel<T> :BaseViewModel, ICrud<T> where T : class, new()
    {
        [ObservableProperty]
        ObservableCollection<T> values;
        [ObservableProperty]
        IEntityStructure structure;


        public CrudViewModel(IDMEEditor dMEditor) : base(dMEditor)
        {
            DMEditor = dMEditor;
            values= new ObservableCollection<T>();
            structure = new EntityStructure();
            values.CollectionChanged += Values_CollectionChanged;

        }

        private void Values_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           switch(e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;

            }
        }

        public Task<IErrorsInfo> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetByFilter(string Filter)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetByFilter(List<AppFilter> Filter)
        {
            throw new NotImplementedException();
        }

        public Task<IErrorsInfo> Insert(T doc)
        {
            throw new NotImplementedException();
        }

        public Task<IErrorsInfo> Update(T doc)
        {
            throw new NotImplementedException();
        }
    }
}
