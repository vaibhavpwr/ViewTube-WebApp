using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavouriteService.Models;

namespace FavouriteService.Services
{
    public interface IFavVideoService
    {
        FavVideo AddFavVideo(FavVideo favVideo);
        FavVideo DeleteFavVideo(FavVideo favVideo);
        List<FavVideo> GetFavVideoList(int userId);
        List<FavVideo> GetFavVideoListOfUser(string userId);
      
    }
}
