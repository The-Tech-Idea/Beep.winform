using System;
using System.Collections.Generic;
using System.Text;
using TheTechIdea.Util;
using BeepEnterprize.Vis.Module;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Threading.Tasks;
using TheTechIdea.Beep.Report;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace TheTechIdea.Beep.ViewModels
{
    public partial class DataConnectionViewModel : BaseViewModel,ICrud<ConnectionProperties>
    {
        [ObservableProperty]
        ConnectionProperties connection;
        public DataConnectionViewModel(IDMEEditor dMEditor) : base(dMEditor)
        {
            DMEditor = dMEditor;
        }

        public IDMEEditor DMEditor { get; }

        public Task<IErrorsInfo> Delete(int id)
        {
            bool retval = Task.Run<bool>(() => DMEditor.ConfigEditor.RemoveConnByID(id)).Result ;
            if (retval)
            {
                DMEditor.ErrorObject.Flag = Errors.Ok;
            }
            else
                DMEditor.ErrorObject.Flag = Errors.Failed;
            return Task.FromResult(DMEditor.ErrorObject);

        }

        public Task<ConnectionProperties> Get(int id)
        {
            return Task.FromResult(DMEditor.ConfigEditor.DataConnections.FirstOrDefault(p => p.ID == id));
        }

        public Task<IEnumerable<ConnectionProperties>> Get()
        {
            return Task.FromResult(DMEditor.ConfigEditor.DataConnections.AsEnumerable());
        }

        public Task<IEnumerable<ConnectionProperties>> GetByFilter(string Filter)
        {

            return Task.FromResult(DMEditor.ConfigEditor.DataConnections.AsQueryable().Where(Filter).ToDynamicList<ConnectionProperties>().AsEnumerable<ConnectionProperties>());
        }

        public Task<IEnumerable<ConnectionProperties>> GetByFilter(List<AppFilter> Filter)
        {
            throw new NotImplementedException();
        }

        public Task<IErrorsInfo> Insert(ConnectionProperties doc)
        {
            bool retval = Task.Run<bool>(() => DMEditor.ConfigEditor.AddDataConnection(doc)).Result;
            if (retval)
            {
                DMEditor.ErrorObject.Flag = Errors.Ok;
            }
            else
                DMEditor.ErrorObject.Flag = Errors.Failed;
            return Task.FromResult(DMEditor.ErrorObject);
        }

        public Task<IErrorsInfo> Update(ConnectionProperties doc)
        {

            bool retval = Task.Run<bool>(() => DMEditor.ConfigEditor.UpdateDataConnection(doc,doc.Category.ToString())).Result;
            if (retval)
            {
                DMEditor.ErrorObject.Flag = Errors.Ok;
            }
            else
                DMEditor.ErrorObject.Flag = Errors.Failed;
            return Task.FromResult(DMEditor.ErrorObject);
        }
    }
}
