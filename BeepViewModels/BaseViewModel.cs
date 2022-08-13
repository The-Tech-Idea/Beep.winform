using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;


namespace TheTechIdea.Beep.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        bool isBusy;
        [ObservableProperty]
        bool isModified;
        [ObservableProperty]
        bool isCreated;
        [ObservableProperty]
        bool isDeleted;
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
           
        }
    }
}
