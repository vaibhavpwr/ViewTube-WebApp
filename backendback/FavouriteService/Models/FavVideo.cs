using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavouriteService.Models
{
    public class FavVideo
    {
       
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }

        public string Thumbnail { get; set; }

        public string VideoTitle { get; set; }

        public string ChannelTitle { get; set; }

        public string VideoId { get; set; }

    }
}

