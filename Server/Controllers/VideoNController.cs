using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using YogIT.Module.VideoN.Repository;
using Oqtane.Controllers;
using System.Net;

namespace YogIT.Module.VideoN.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class VideoNController : ModuleControllerBase
    {
        private readonly IVideoNRepository _VideoNRepository;

        public VideoNController(IVideoNRepository VideoNRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _VideoNRepository = VideoNRepository;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.VideoN> Get(string moduleid)
        {
            int ModuleId;
            if (int.TryParse(moduleid, out ModuleId) && IsAuthorizedEntityId(EntityNames.Module, ModuleId))
            {
                return _VideoNRepository.GetVideoNs(ModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized VideoN Get Attempt {ModuleId}", moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.VideoN Get(int id)
        {
            Models.VideoN VideoN = _VideoNRepository.GetVideoN(id);
            if (VideoN != null && IsAuthorizedEntityId(EntityNames.Module, VideoN.ModuleId))
            {
                return VideoN;
            }
            else
            { 
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized VideoN Get Attempt {VideoNId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.VideoN Post([FromBody] Models.VideoN VideoN)
        {
            if (ModelState.IsValid && IsAuthorizedEntityId(EntityNames.Module, VideoN.ModuleId))
            {
                VideoN = _VideoNRepository.AddVideoN(VideoN);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "VideoN Added {VideoN}", VideoN);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized VideoN Post Attempt {VideoN}", VideoN);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                VideoN = null;
            }
            return VideoN;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.VideoN Put(int id, [FromBody] Models.VideoN VideoN)
        {
            if (ModelState.IsValid && IsAuthorizedEntityId(EntityNames.Module, VideoN.ModuleId) && _VideoNRepository.GetVideoN(VideoN.VideoNId, false) != null)
            {
                VideoN = _VideoNRepository.UpdateVideoN(VideoN);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "VideoN Updated {VideoN}", VideoN);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized VideoN Put Attempt {VideoN}", VideoN);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                VideoN = null;
            }
            return VideoN;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.VideoN VideoN = _VideoNRepository.GetVideoN(id);
            if (VideoN != null && IsAuthorizedEntityId(EntityNames.Module, VideoN.ModuleId))
            {
                _VideoNRepository.DeleteVideoN(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "VideoN Deleted {VideoNId}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized VideoN Delete Attempt {VideoNId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
