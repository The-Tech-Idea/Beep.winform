using System;
using System.Collections.Generic;
using System.Text;
using TheTechIdea.Beep.AppModule;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Report;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.AppBuilder
{
    [AddinAttribute(Caption = "Beep APP", Name = "BeepAPP", misc = "BeepAPP", addinType = AddinType.Class,iconimage ="app.ico")]
    public class App : IApp
    {
       
        public App()
        {
            ID = Guid.NewGuid().ToString();
            CreateDate = DateTime.Now;
            Ver = 1;
            initBreadCrumb();
        }
        public App(string pAppName, string pDataViewDataSourceName, AppType pApptype)
        {
            ID = Guid.NewGuid().ToString();
            AppName = pAppName;
            DataViewDataSourceName = pDataViewDataSourceName;
            Apptype = pApptype;
            CreateDate = DateTime.Now;
            Ver = 1;
            initBreadCrumb();
        }
        public App(string pAppName, string pDataViewDataSourceName, AppType pApptype, string pOuputFolder)
        {
            ID = Guid.NewGuid().ToString();
            AppName = pAppName;
            DataViewDataSourceName = pDataViewDataSourceName;
            Apptype = pApptype;
            CreateDate = DateTime.Now;
            OuputFolder = pOuputFolder;
            Ver = 1;
            initBreadCrumb();
        }
        private void initBreadCrumb()
        {
            BreadCrumb x = new BreadCrumb();
            x.screenname = "HOME";
            breadCrumb.AddFirst(x);
        }
        public string ID { get; set; }
        public string AppName { get ; set ; }
        public string DataViewDataSourceName { get ; set ; }
        public DateTime CreateDate { get ; set ; }
        public DateTime UpdateDate { get ; set ; }
        public int Ver { get ; set ; }
        public AppType Apptype { get ; set ; }
        public string OuputFolder { get; set; }
        public string Startupscrreen { get; set; }
        public List<IAppScreen> Screens { get; set; } = new List<IAppScreen>();
        public List<IEntityStructure> Entities { get; set; } = new List<IEntityStructure>();
        public string ImageLogoName { get; set; }
        public string AppTitle { get; set; }
        public string AppSubTitle { get; set; }
        public string AppDescription { get; set; }
        public LinkedList<IBreadCrumb> breadCrumb { get; set; } = new LinkedList<IBreadCrumb>();
        public List<IAppVersion> AppVersions { get; set; } = new List<IAppVersion>();
        public List<ConnectionProperties> dataConnections { get; set; } = new List<ConnectionProperties>();
    }
}
