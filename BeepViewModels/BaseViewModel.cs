using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheTechIdea.Beep.ViewModels.Enums;

namespace TheTechIdea.Beep.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        bool isBusy;

        [ObservableProperty]
        DateTime createDate;
        [ObservableProperty]
        DateTime createBy;

        [ObservableProperty]
        List<RecordTrace> recordTraces = new List<RecordTrace>();
        [ObservableProperty]
        RecordTrace currentRecordTrace;

        [ObservableProperty]
        DateTime dateCreated;
        [ObservableProperty]
        DateTime dateUpdated;
        [ObservableProperty]
        string createdBy;
        [ObservableProperty]
        string updatedBy;

        public IDMEEditor DMEditor { get; set; }
       

        public BaseViewModel(IDMEEditor dMEditor)
        {
            DMEditor = dMEditor;
            recordTraces = new List<RecordTrace>();
        }
        public void UpdateRecordTrace(int id,string guid,RecordStatus original,RecordStatus current)
        {
            RecordTrace fnd = new RecordTrace();
            int idx=recordTraces.FindIndex(p=>p.ID.Equals(id));
            if(idx==-1)
            {
                fnd=new RecordTrace() { ID=id, GuidId=guid, OriginalStatus=original,Status=current};
                recordTraces.Add(fnd);
            }
            else
            {
                fnd = recordTraces[idx];
                fnd.Status=current;
            }
        }
    }
}
