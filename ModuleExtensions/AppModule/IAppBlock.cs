using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea.Beep.AppManager;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Report;

namespace TheTechIdea.Beep.AppModule
{
    public interface IAppBlock
    {
        IEntityStructure Entity { get; set; }
        string Name { get; set; }
        List<IAppField> Fields { get; set; }
        BlockDisplayType DisplayType { get; set; }
        List<IAppDefinition> Reports { get; set; }
        List<IAppBlock> ChildBlocks { get; set; }   
        string ID { get; set; }
        event EventHandler<IAppBlock> Fill;
        event EventHandler<IAppBlock> PreFill;
        event EventHandler<IAppBlock> FillChilds;
        event EventHandler<IAppBlock> Validate;
        event EventHandler<IAppBlock> PreSave;
        event EventHandler<IAppBlock> AfterSave;
        event EventHandler<IAppBlock> PreShow;
        event EventHandler<IAppBlock> AfterShow;
        event EventHandler<IAppBlock> PreClose;
        event EventHandler<IAppBlock> AfterClose;
    }
}
