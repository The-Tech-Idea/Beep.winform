using CommunityToolkit.Mvvm.ComponentModel;
using Dhub3.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea.Beep;

namespace KOC.DHUB3.ViewModels
{
    public class BaseViewModel:ObservableObject
    {
        
            
        [ObservableProperty]
        private bool isBusy;
        [ObservableProperty]
        private DateTime dateCreated;
        [ObservableProperty]
        private DateTime dateUpdated;
        [ObservableProperty]
        private string createdBy;
        [ObservableProperty]
        private string updatedBy;

        public IDMEEditor DMEditor { get; set; }   
        public DataRepo Repo { get; set; }

    }
}
