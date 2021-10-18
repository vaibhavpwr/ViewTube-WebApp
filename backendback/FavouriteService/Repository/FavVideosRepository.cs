using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavouriteService.Models;
using Microsoft.EntityFrameworkCore;

namespace FavouriteService.Repository
{
    public class FavVideosRepository : IFavVideosRepository
    {
        private readonly FavVideosContext _context;
        public FavVideosRepository(FavVideosContext context)
        {
            _context = context;
        }
       
        public List<FavVideo> GetFavVideoList(int Id)
        {
            var favVideoList = _context.FavVideosTable.Where(v => v.Id == Id).ToList();
            return favVideoList;
        }

        public List<FavVideo> GetFavVideoListofUser(string userId)
        {
            var favVideoList = _context.FavVideosTable.Where(v => v.UserId == userId).ToList();
            return favVideoList;
        }

        public FavVideo AddFavVideo(FavVideo favVideo)
        {
            _context.FavVideosTable.Add(favVideo);
            _context.SaveChanges();
            return favVideo;
        }


        public FavVideo DeleteFavVideo(FavVideo favVideo)
        {
            FavVideo favVideoToDelete;
            favVideoToDelete = _context.FavVideosTable.Where(v => v.UserId == favVideo.UserId && v.VideoId == favVideo.VideoId).FirstOrDefault();
            _context.FavVideosTable.Remove(favVideoToDelete);
            _context.SaveChanges();
            return favVideoToDelete;
        }

        public async Task<bool> IsVideoExist(string UserId, string favouriteId)
        {
            List<FavVideo> favourites = await _context.FavVideosTable.Where(x => x.UserId == UserId).ToListAsync();
            if (favourites.Count != 0)
            {
                FavVideo fav = favourites.FirstOrDefault(x => x.VideoId == favouriteId);
                if (fav != null)
                    return true;

            }
            return false;
        }

    }
}
