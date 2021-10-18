using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavouriteService.Models;

namespace FavouriteService.Repository
{
    public interface IFavVideosRepository
    {
        FavVideo AddFavVideo(FavVideo favVideo);
        FavVideo DeleteFavVideo(FavVideo favVideo);

        List<FavVideo> GetFavVideoList(int userId);

        List<FavVideo> GetFavVideoListofUser(string userId);

        // FavVideo GetFavVideo(FavVideo favVideo);
    }
}
