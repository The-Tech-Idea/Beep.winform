using System.Collections.Generic;
using BeepEnterprize.Winform.Vis.Wizards;
using TheTechIdea;
using TheTechIdea.Beep;

namespace BeepEnterprize.Vis.Module
{
    public interface IWizardManager
    {
        string Title { get; set; }
        string Description { get; set; }
        int Count { get; }
        IWizardNode entryform { get; }
        LinkedList<IWizardNode> Nodes { get; set; }
        int SelectedIndex { get; }
        IWizardNode lastform { get; }
        WizardState State { get; set; }
         int StartLeft { get; set; }
         int StartTop { get; set; } 
        bool Isloaded { get; set; }
        bool IsSaved { get; set; }  
        bool IsEdited { get; set; }
        bool IsEditing { get; set; }
        bool IsHidden { get; set; }
        bool IsVisible { get; set; }

         int CurrentIdx { get;  }
        IDMEEditor DMEEditor { get; set; }
        void MoveNext();
        void MovePrevious();
        void InitWizardForm();
        void Show();
         void Hide();
       
       
    }
}