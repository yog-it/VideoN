using System.Collections.Generic;
using System.Threading.Tasks;
using YogIT.Module.VideoN.Models;

namespace YogIT.Module.VideoN.Services
{
    public interface IVideoNService 
    {
        Task<List<Models.VideoN>> GetVideoNsAsync(int ModuleId);

        Task<Models.VideoN> GetVideoNAsync(int VideoNId, int ModuleId);

        Task<Models.VideoN> AddVideoNAsync(Models.VideoN VideoN);

        Task<Models.VideoN> UpdateVideoNAsync(Models.VideoN VideoN);

        Task DeleteVideoNAsync(int VideoNId, int ModuleId);
    }
}
