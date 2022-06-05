
using CommunityToolkit.Mvvm.ComponentModel;
using Dhub3.DataServices;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea.Beep;

namespace KOC.DHUB3.ViewModels
{
    public partial  class BaseViewModel:ObservableObject
    {
        
            
        [ObservableProperty]
         bool isBusy;
        [ObservableProperty]
         DateTime dateCreated;
        [ObservableProperty]
         DateTime dateUpdated;
        [ObservableProperty]
         string createdBy;
        [ObservableProperty]
         string updatedBy;

        public IDMEEditor DMEditor { get; set; }   
        public DataRepo Repo { get; set; }
       


    }
}
