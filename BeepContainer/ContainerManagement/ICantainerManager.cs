using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TheTechIdea.Beep.Containers.Models;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.Containers.ContainerManagement
{
    public interface ICantainerManager
    {
        List<BeepContainer> Containers { get; set; }
        ErrorsInfo ErrorsandMesseges { get; set; }

        Task<ErrorsInfo> AddUpdateContainer(BeepContainer pContainer);
        Task<ErrorsInfo> CreateContainer(string pContainerName, IServiceCollection pservices, string pContainerFolderPath);
        Task<ErrorsInfo> CreateContainer(string pContainerName, IServiceCollection pservices, string pContainerFolderPath, string pSecretKey, string pTokenKey);
        Task<ErrorsInfo> CreateContainerFileSystem(BeepContainer pContainer);
       Task<ErrorsInfo> RemoveContainer(string pContainerName);
    }
}