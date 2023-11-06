using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using YogIT.Module.VideoN.Models;

namespace YogIT.Module.VideoN.Repository
{
    public class VideoNRepository : IVideoNRepository, ITransientService
    {
        private readonly VideoNContext _db;

        public VideoNRepository(VideoNContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.VideoN> GetVideoNs(int ModuleId)
        {
            return _db.VideoN.Where(item => item.ModuleId == ModuleId);
        }

        public Models.VideoN GetVideoN(int VideoNId)
        {
            return GetVideoN(VideoNId, true);
        }

        public Models.VideoN GetVideoN(int VideoNId, bool tracking)
        {
            if (tracking)
            {
                return _db.VideoN.Find(VideoNId);
            }
            else
            {
                return _db.VideoN.AsNoTracking().FirstOrDefault(item => item.VideoNId == VideoNId);
            }
        }

        public Models.VideoN AddVideoN(Models.VideoN VideoN)
        {
            _db.VideoN.Add(VideoN);
            _db.SaveChanges();
            return VideoN;
        }

        public Models.VideoN UpdateVideoN(Models.VideoN VideoN)
        {
            _db.Entry(VideoN).State = EntityState.Modified;
            _db.SaveChanges();
            return VideoN;
        }

        public void DeleteVideoN(int VideoNId)
        {
            Models.VideoN VideoN = _db.VideoN.Find(VideoNId);
            _db.VideoN.Remove(VideoN);
            _db.SaveChanges();
        }
    }
}
