using Dapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
using System.Linq;
using TheTechIdea.Beep.ConfigUtil;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Logger;
using TheTechIdea.Tools;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.Containers.Services
{
    public class BeepMain :IBeepDMService
    {
        public BeepMain(IServiceCollection services)
    {
        Services = services;


    }
    bool isDev = false;

    #region "System Components"
    public IDMEEditor DMEEditor { get; set; }
    public IConfigEditor Config_editor { get; set; }
    public IDMLogger lg { get; set; }
    public IUtil util { get; set; }

    public IErrorsInfo Erinfo { get; set; }
    public IJsonLoader jsonLoader { get; set; }
    public IAssemblyHandler LLoader { get; set; }



    public IServiceCollection Services { get; }
    CancellationTokenSource tokenSource;
    CancellationToken token;
    #endregion
    public void Configure() //ContainerBuilder builder
    {
        Erinfo = new ErrorsInfo();
        lg = new DMLogger();
        jsonLoader = new JsonLoader();
        string root = "";
        root = AppContext.BaseDirectory + ("Beep");
        Config_editor = new ConfigEditor(lg, Erinfo, jsonLoader, root);
        util = new Util(lg, Erinfo, Config_editor);
        LLoader = new AssemblyHandler(Config_editor, Erinfo, lg, util);
        DMEEditor = new DMEEditor(lg, util, Erinfo, Config_editor, LLoader);
        try
        {
            Services.AddSingleton<IErrorsInfo>(Erinfo);
            Services.AddSingleton<IDMLogger>(lg);
            Services.AddSingleton<IConfigEditor>(Config_editor);
            Services.AddSingleton<IDMEEditor>(DMEEditor);
            Services.AddSingleton<IUtil>(util);
            Services.AddSingleton<IJsonLoader>(jsonLoader);

        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
        var progress = new Progress<PassedArgs>(percent => {


        });
        LLoader.LoadAllAssembly(progress, token);
        Config_editor.LoadedAssemblies = LLoader.Assemblies.Select(c => c.DllLib).ToList();
        // Setup the Entry Screen 
        // the screen has to be in one the Addin DLL's loaded by the Assembly loader


    }

    #region "Dapper Methods"
  

    public bool AddConnection(string pConnectionName, DataSourceType dataSourceType)
    {
        return true;
    }


    #endregion "Dapper Methods"
}
}
