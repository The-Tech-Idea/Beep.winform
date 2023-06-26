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
using System.Collections.ObjectModel;

namespace Beep.ViewModels
{
    public partial class DataConnectionViewModel : BaseViewModel, ICrud<ConnectionProperties>
    {
        [ObservableProperty]
        ConnectionProperties currentConnection;
        [ObservableProperty]
        ObservableCollection<ConnectionProperties> connections;

       
        public DataConnectionViewModel(TheTechIdea.Beep.IDMEEditor dMEditor) : base(dMEditor)
        {
            DMEditor = dMEditor;
            connections=new ObservableCollection<ConnectionProperties>();
            RecordTraces=new List<RecordTrace>();
            CurrentRecordTrace.OriginalStatus = Enums.RecordStatus.Modified;
        }

        public Task<IErrorsInfo> Delete(int id)
        {
            RecordTraces.Add(new RecordTrace() { ID = id, OriginalStatus = Enums.RecordStatus.Modified, Status = Enums.RecordStatus.Deleted });
            bool retval = Task.Run(() => DMEditor.ConfigEditor.RemoveConnByID(id)).Result ;
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
            UpdateRecordTrace(doc.ID, null, Enums.RecordStatus.New, Enums.RecordStatus.New);
            bool retval = Task.Run(() => DMEditor.ConfigEditor.AddDataConnection(doc)).Result;
            if (retval)
            {
                UpdateRecordTrace(doc.ID, null, Enums.RecordStatus.New, Enums.RecordStatus.Idle);
                DMEditor.ErrorObject.Flag = Errors.Ok;
            }
            else
                DMEditor.ErrorObject.Flag = Errors.Failed;
            return Task.FromResult(DMEditor.ErrorObject);
        }

        public Task<IErrorsInfo> Update(ConnectionProperties doc)
        {

            bool retval = Task.Run(() => DMEditor.ConfigEditor.UpdateDataConnection(doc,doc.Category.ToString())).Result;
            if (retval)
            {
                UpdateRecordTrace(doc.ID, null, Enums.RecordStatus.Modified, Enums.RecordStatus.Idle);
                DMEditor.ErrorObject.Flag = Errors.Ok;
            }
            else
                DMEditor.ErrorObject.Flag = Errors.Failed;
            return Task.FromResult(DMEditor.ErrorObject);
        }
    }
}
