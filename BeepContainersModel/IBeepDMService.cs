


using TheTechIdea.Beep.ConfigUtil;
using TheTechIdea.Beep.Editor;
using TheTechIdea.Beep.Workflow;
using TheTechIdea.Logger;
using TheTechIdea.Tools;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.Containers.Services
{
    public interface IBeepDMService
    {
        IDMEEditor DMEEditor { get; set; }
        IClassCreator ClassCreator { get; set; }
        IConfigEditor Configeditor { get; set; }
        IErrorsInfo Erinfo { get; set; }
        IETL eTL { get; set; }
        IJsonLoader JsonLoader { get; set; }
        IDMLogger Logger { get; set; }
        IAssemblyHandler LLoader { get; set; }
        IDataTypesHelper TypesHelper { get; set; }
        IUtil Util { get; set; }
        IWorkFlowEditor WorkFlowEditor { get; set; }

        bool AddConnection(string pConnectionName, DataSourceType dataSourceType);
        void ConfigureServices();
        IDataSource CreateConnection(string ConnName);
    }
}