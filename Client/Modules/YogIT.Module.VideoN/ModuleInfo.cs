using Oqtane.Models;
using Oqtane.Modules;

namespace YogIT.Module.VideoN
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "VideoN",
            Description = "A module extension for Oqtane to play videos using the Videojs player",
            Version = "1.0.0",
            ServerManagerType = "YogIT.Module.VideoN.Manager.VideoNManager, YogIT.Module.VideoN.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "YogIT.Module.VideoN.Shared.Oqtane",
            PackageName = "YogIT.Module.VideoN" 
        };
    }
}
