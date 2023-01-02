using BeepEnterprize.Vis.Module;
using TheTechIdea.Beep;

namespace BeepEnterprize.Winform.Vis.Helpers
{
    public interface IVisHelper
    {
        IDMEEditor DMEEditor { get; set; }
        IVisManager Vismanager { get; set; }
     
        int GetImageIndex(string imagename, int size);
        int GetImageIndexFromConnectioName(string Connectioname, int size);
    }
}