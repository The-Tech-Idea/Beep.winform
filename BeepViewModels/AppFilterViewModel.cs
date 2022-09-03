using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Report;

namespace TheTechIdea.Beep.ViewModels
{
    public partial class AppFilterViewModel : BaseViewModel
    {
        public AppFilterViewModel(IDMEEditor dMEditor) : base(dMEditor)
        {
        }
        [ObservableProperty]
        List<AppFilter> filters;

        [RelayCommand]
        void GetFilters(EntityStructure entity)
        {
            filters=entity.Filters;
        }

        [RelayCommand]  
        void InsertFilter(AppFilter filter)
        {
            filters.Add(filter);
        }
        [RelayCommand]
        void DeleteFilter(AppFilter filter)
        {
            filters.Remove(filter);
        }



    }
}
