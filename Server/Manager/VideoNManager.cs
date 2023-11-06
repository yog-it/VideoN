using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Enums;
using Oqtane.Repository;
using YogIT.Module.VideoN.Repository;

namespace YogIT.Module.VideoN.Manager
{
    public class VideoNManager : MigratableModuleBase, IInstallable, IPortable
    {
        private readonly IVideoNRepository _VideoNRepository;
        private readonly IDBContextDependencies _DBContextDependencies;

        public VideoNManager(IVideoNRepository VideoNRepository, IDBContextDependencies DBContextDependencies)
        {
            _VideoNRepository = VideoNRepository;
            _DBContextDependencies = DBContextDependencies;
        }

        public bool Install(Tenant tenant, string version)
        {
            return Migrate(new VideoNContext(_DBContextDependencies), tenant, MigrationType.Up);
        }

        public bool Uninstall(Tenant tenant)
        {
            return Migrate(new VideoNContext(_DBContextDependencies), tenant, MigrationType.Down);
        }

        public string ExportModule(Oqtane.Models.Module module)
        {
            string content = "";
            List<Models.VideoN> VideoNs = _VideoNRepository.GetVideoNs(module.ModuleId).ToList();
            if (VideoNs != null)
            {
                content = JsonSerializer.Serialize(VideoNs);
            }
            return content;
        }

        public void ImportModule(Oqtane.Models.Module module, string content, string version)
        {
            List<Models.VideoN> VideoNs = null;
            if (!string.IsNullOrEmpty(content))
            {
                VideoNs = JsonSerializer.Deserialize<List<Models.VideoN>>(content);
            }
            if (VideoNs != null)
            {
                foreach(var VideoN in VideoNs)
                {
                    _VideoNRepository.AddVideoN(new Models.VideoN { ModuleId = module.ModuleId, Title = VideoN.Title });
                }
            }
        }
    }
}
