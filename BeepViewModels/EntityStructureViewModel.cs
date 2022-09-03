using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;
using TheTechIdea.Beep.DataBase;

namespace TheTechIdea.Beep.ViewModels
{
    public partial class EntityStructureViewModel : BaseViewModel
    {
        public EntityStructureViewModel(IDMEEditor dMEditor) : base(dMEditor)
        {
        }
        [ObservableProperty]
        EntityStructure entity;
        [ObservableProperty]
        string entityName;
        [ObservableProperty]
        string dataSourceName;

        [RelayCommand]
        void AddRelation(RelationShipKeys relatedentity)
        {
            entity.Relations.Add(relatedentity);
        }
        [RelayCommand]
        void RemoveRelation(RelationShipKeys relatedentity)
        {
            entity.Relations.Add(relatedentity);
        }
        [RelayCommand]
        void EditRelation(RelationShipKeys relatedentity)
        {

            entity.Relations.Add(relatedentity);
        }

    }
}
