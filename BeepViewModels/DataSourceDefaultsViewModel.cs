﻿using BeepEnterprize.Vis.Module;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea.Beep.Report;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.ViewModels
{
    public class DataSourceDefaultsViewModel : BaseViewModel, ICrud<DefaultValue>
    {
        [ObservableProperty]
        ConnectionProperties currentConnection;
        [ObservableProperty]
        ObservableCollection<DefaultValue> connections;


        public DataSourceDefaultsViewModel(IDMEEditor dMEditor) : base(dMEditor)
        {
            DMEditor = dMEditor;
            connections = new ObservableCollection<DefaultValue>();
            RecordTraces = new List<RecordTrace>();
            CurrentRecordTrace.OriginalStatus = Enums.RecordStatus.Modified;
        }

        public Task<IErrorsInfo> Delete(int id)
        {
            RecordTraces.Add(new RecordTrace() { ID = id, OriginalStatus = Enums.RecordStatus.Modified, Status = Enums.RecordStatus.Deleted });
            bool retval = Task.Run<bool>(() => DMEditor.ConfigEditor.RemoveConnByID(id)).Result;
            if (retval)
            {
                DMEditor.ErrorObject.Flag = Errors.Ok;
            }
            else
                DMEditor.ErrorObject.Flag = Errors.Failed;
            return Task.FromResult(DMEditor.ErrorObject);

        }

        public Task<DefaultValue> Get(int id)
        {
            return Task.FromResult(DMEditor.ConfigEditor.DataConnections.FirstOrDefault(p => p.ID == id));

        }

        public Task<IEnumerable<DefaultValue>> Get()
        {
            return Task.FromResult(DMEditor.ConfigEditor..AsEnumerable());
        }

        public Task<IEnumerable<DefaultValue>> GetByFilter(string Filter)
        {

            return Task.FromResult(DMEditor.ConfigEditor.DataConnections.AsQueryable().Where(Filter).ToDynamicList<ConnectionProperties>().AsEnumerable<ConnectionProperties>());
        }

        public Task<IEnumerable<DefaultValue>> GetByFilter(List<AppFilter> Filter)
        {
            throw new NotImplementedException();
        }

        public Task<IErrorsInfo> Insert(DefaultValue doc)
        {
            UpdateRecordTrace(doc.ID, null, Enums.RecordStatus.New, Enums.RecordStatus.New);
            bool retval = Task.Run<bool>(() => DMEditor.ConfigEditor.AddDataConnection(doc)).Result;
            if (retval)
            {
                UpdateRecordTrace(doc.ID, null, Enums.RecordStatus.New, Enums.RecordStatus.Idle);
                DMEditor.ErrorObject.Flag = Errors.Ok;
            }
            else
                DMEditor.ErrorObject.Flag = Errors.Failed;
            return Task.FromResult(DMEditor.ErrorObject);
        }

        public Task<IErrorsInfo> Update(DefaultValue doc)
        {

            bool retval = Task.Run<bool>(() => DMEditor.ConfigEditor.UpdateDataConnection(doc, doc.Category.ToString())).Result;
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
