using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;

namespace YogIT.Module.VideoN.Services
{
    public class VideoNService : ServiceBase, IVideoNService, IService
    {
        public VideoNService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("VideoN");

        public async Task<List<Models.VideoN>> GetVideoNsAsync(int ModuleId)
        {
            List<Models.VideoN> VideoNs = await GetJsonAsync(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", EntityNames.Module, ModuleId), Enumerable.Empty<Models.VideoN>().ToList());
            return VideoNs.OrderBy(item => item.Title).ToList();
        }

        public async Task<Models.VideoN> GetVideoNAsync(int VideoNId, int ModuleId)
        {
            return await GetJsonAsync<Models.VideoN>(CreateAuthorizationPolicyUrl($"{Apiurl}/{VideoNId}", EntityNames.Module, ModuleId));
        }

        public async Task<Models.VideoN> AddVideoNAsync(Models.VideoN VideoN)
        {
            return await PostJsonAsync(CreateAuthorizationPolicyUrl($"{Apiurl}", EntityNames.Module, VideoN.ModuleId), VideoN);
        }

        public async Task<Models.VideoN> UpdateVideoNAsync(Models.VideoN VideoN)
        {
            return await PutJsonAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{VideoN.VideoNId}", EntityNames.Module, VideoN.ModuleId), VideoN);
        }

        public async Task DeleteVideoNAsync(int VideoNId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{VideoNId}", EntityNames.Module, ModuleId));
        }
    }
}
