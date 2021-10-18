using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ViewApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoController : ControllerBase
    {
        

        private readonly ILogger<VideoController> _logger;

        string apikey = "AIzaSyCraiN3SHc-ADRuxRjPHhfN1c0wI-suAmg";

        public VideoController(ILogger<VideoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("get-videos")]

        public async Task<String> GetVideos()
        {
            var Url = "https://www.googleapis.com/youtube/v3/videos?part=snippet&chart=mostPopular&regionCode=in&maxResults=10&key=" + apikey;
            var httpClient = new HttpClient();
            var responce = await httpClient.GetAsync(Url);
            return await responce.Content.ReadAsStringAsync();
        }


        [HttpGet]
        [Route("get-category")]
        public async Task<String> GetCategoryId()
        {
            var Url = "https://www.googleapis.com/youtube/v3/videoCategories?part=snippet&regionCode=in&key=" + apikey;
            var httpClient = new HttpClient();
            var responce = await httpClient.GetAsync(Url);
            var categories = await responce.Content.ReadAsStringAsync();
            return categories;
        }

        [HttpGet]
        [Route("get-tendings")]
        public async Task<String> GetTrendings(int categoryId)
        {          
            var Url = "https://www.googleapis.com/youtube/v3/videos?part=snippet&regionCode=in&maxResults=10&videoCategoryId=" + categoryId + "&chart=mostPopular&key=" + apikey;
            var httpClient = new HttpClient();
            var responce = await httpClient.GetAsync(Url);
            return await responce.Content.ReadAsStringAsync();
        }


        [HttpGet]
        [Route("search")]
        public async Task<String> SearchVideo(string searchText)
        {
            //var searchText ="Mohanlal" ;
            var Url = "https://www.googleapis.com/youtube/v3/search?part=snippet&maxResults=10&q=" + searchText + "&key=" + apikey;           
            var httpClient = new HttpClient();
            var responce = await httpClient.GetAsync(Url);
            return await responce.Content.ReadAsStringAsync();
        }

    }
}
