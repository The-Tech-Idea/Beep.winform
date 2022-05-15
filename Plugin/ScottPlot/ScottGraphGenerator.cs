using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.ScottPlots
{
    public class ScottGraphGenerator
    {
        public ScottGraphGenerator(IDMEEditor dMEditor)
        {
            DMEditor = dMEditor;
        }

        public IDMEEditor DMEditor { get; }
        public Bitmap PlotImage { get; }
        public IErrorsInfo GetGraph(string graphtype,object grpahdata)
        {
            try
            {
                DMEditor.ErrorObject.Ex = null;
                DMEditor.ErrorObject.Flag = Errors.Ok;
                var plt = new ScottPlot.Plot(500, 300);
                plt.Render(PlotImage);
            }
            catch (Exception ex)
            {
                DMEditor.AddLogMessage("Beep", $"Error in  {System.Reflection.MethodBase.GetCurrentMethod().Name} -  {ex.Message}", DateTime.Now, 0, null, Errors.Failed);
            }
            return DMEditor.ErrorObject;
        }
    }
}
