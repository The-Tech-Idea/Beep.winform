using System;
using System.Collections.Generic;
using System.Text;
using TheTechIdea.Util;
using BeepEnterprize.Vis.Module;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Threading.Tasks;
using TheTechIdea.Beep.Report;

namespace TheTechIdea.Beep.ViewModels
{
    public partial class DataConnectionViewModel : BaseViewModel,ICrud<ConnectionProperties>
    {
        [ObservableProperty]
        ConnectionProperties Connection;
        public DataConnectionViewModel(IDMEEditor dMEditor) : base(dMEditor)
        {
            DMEditor = dMEditor;
        }

        public IDMEEditor DMEditor { get; }

        public Task<IErrorsInfo> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ConnectionProperties> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ConnectionProperties>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ConnectionProperties>> GetByFilter(string Filter)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ConnectionProperties>> GetByFilter(List<AppFilter> Filter)
        {
            throw new NotImplementedException();
        }

        public Task<IErrorsInfo> Insert(ConnectionProperties doc)
        {
            throw new NotImplementedException();
        }

        public Task<IErrorsInfo> Update(ConnectionProperties doc)
        {
            throw new NotImplementedException();
        }
    }
}
