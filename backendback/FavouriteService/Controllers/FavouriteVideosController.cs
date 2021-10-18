using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavouriteService.Models;
using FavouriteService.Services;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;

namespace FavouriteService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FavouriteVideosController : ControllerBase
    {
       
        private readonly IFavVideoService service;
        private readonly FavVideosContext context;
        public FavouriteVideosController(IFavVideoService _service, FavVideosContext _context)
        {
            this.service = _service;
            this.context = _context;
        }

        [HttpGet]
        [Route("getUserVideo")]
        public IActionResult GetVideosListOfUser(string userId)
        {
            var favVideoListofUSer = service.GetFavVideoListOfUser(userId);
            return StatusCode(200, favVideoListofUSer);

        }

        [HttpPost]
        [Route("add")]     
        public IActionResult AddVideo(FavVideo favVideo)
        {
            var favExist = context.FavVideosTable.Where(x => x.UserId == favVideo.UserId && x.VideoId == favVideo.VideoId).FirstOrDefault();
            if(favExist == null)
            {
                if (ModelState.IsValid)
                {
                    service.AddFavVideo(favVideo);
                    //return favVideo;
                    return Ok("created");
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpDelete]
        [Route("Remove")]
        public IActionResult Remove(FavVideo favVideo)
        {
            var favExist = context.FavVideosTable.Where(x => x.UserId == favVideo.UserId && x.VideoId == favVideo.VideoId).FirstOrDefault();
            if (favExist != null)
            {
                if (ModelState.IsValid)
                {
                    service.DeleteFavVideo(favVideo);
                    //return favVideo;
                    return Ok("Remove");
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
    }

}
