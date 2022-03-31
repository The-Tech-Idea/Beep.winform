using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuGet;
using TheTechIdea.Beep;

namespace TheTechIdea.NuggetDriversHandler
{
    public class NuggetHandler
    {
        IDMEEditor DMEEditor { get; set; }
        public List<string> PackageIDs { get; set; }
        public List<IPackage> Packages { get; set; }
        public IPackageRepository PackageRepository { get; set; }
        public PackageManager PackageManager { get; set; }
        public NuggetHandler(IDMEEditor dMEEditor)
        {
            DMEEditor = dMEEditor;
            //Connect to the official package repository IPackageRepository
            PackageRepository = PackageRepositoryFactory.Default.CreateRepository("https://packages.nuget.org/api/v2");
            //Initialize the package manager string path = <PATH_TO_WHERE_THE_PACKAGES_SHOULD_BE_INSTALLED>
            PackageManager = new PackageManager(PackageRepository, DMEEditor.ConfigEditor.ExePath);
        }
        public bool GetPackages()
        {
            if (PackageRepository != null)
            {
                Packages = PackageRepository.FindPackages(PackageIDs).ToList();
            }
            if (Packages != null)
            {
                return true;
            }else
                return false;
        }
        public bool InstallPackage(string PackageID,string version)
        {
            if(PackageRepository != null)
            {
                if (!string.IsNullOrEmpty(PackageID))
                {
                    try
                    {
                        PackageManager.InstallPackage(PackageID, SemanticVersion.Parse(version));
                        DMEEditor.AddLogMessage("Beep", $"Installed Package {PackageID}-{version}", DateTime.Now, 0, null, Util.Errors.Ok);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        DMEEditor.AddLogMessage("Beep", $"Error Could not Install Package {PackageID}-{version}", DateTime.Now, 0, null, Util.Errors.Failed);
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
