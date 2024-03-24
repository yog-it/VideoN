using System.Collections.Generic;

namespace YogIT.Module.VideoN.Repository
{
    public interface IVideoNRepository
    {
        IEnumerable<Models.VideoN> GetVideoNs(int ModuleId);
        Models.VideoN GetVideoN(int VideoNId);
        Models.VideoN GetVideoN(int VideoNId, bool tracking);
        Models.VideoN AddVideoN(Models.VideoN VideoN);
        Models.VideoN UpdateVideoN(Models.VideoN VideoN);
        void DeleteVideoN(int VideoNId);
    }
}
