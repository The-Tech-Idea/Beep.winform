
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;
using TheTechIdea.Beep.ViewModels.Enums;

namespace TheTechIdea.Beep.ViewModels
{
    public partial class RecordTrace : ObservableObject
    {
        [ObservableProperty]
         int iD;
        [ObservableProperty]
         string guidId;
        [ObservableProperty]
         RecordStatus status;
        [ObservableProperty]
         RecordStatus originalStatus;
    }
}
