using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using FavouriteService.Services;
using NUnit.Framework;
using System.Threading.Tasks;
using FavouriteService.Models;
using FavouriteService.Controllers;
using FavouriteService.Repository;
using Moq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace TestProject
{
    class FavouriteTest
    {
        [Test]
        public void GetShouldReturnOk()
        {

            string userId = "sam";
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
               new Claim("userId", userId)
            }, "mock"));
            List<FavVideo> favourites = new List<FavVideo>()
            {
               new FavVideo{Id=3,UserId="sam",Thumbnail="https://i.ytimg.com/vi/nx_LVO-j7Ds/mqdefault.jpg",VideoTitle="Naukar rocks mumma shocks😂 #shorts",ChannelTitle="Harsh Malhotra",VideoId="nx_LVO-j7Ds"}
             };
            var mockService = new Mock<IFavVideoService>();
            var mockService1 = new Mock<FavVideosContext>();

            mockService.Setup(svc => svc.GetFavVideoListOfUser(userId).Equals(true));
            //var controller = new FavouriteVideosController(mockService.Object);
            var controller = new FavouriteVideosController(mockService.Object, mockService1.Object);

            controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext { User = user } };

            var actual = controller.GetVideosListOfUser(userId);
            Assert.IsInstanceOf<OkObjectResult>(actual);

        }

        [Test]
        public void GetShouldReturnNotfound()
        {

            string userId = "sam";
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
              new Claim("userId", userId)
            }, "mock"));
            List<FavVideo> favourites = new List<FavVideo>()
             {
               new FavVideo{Id=3,UserId="sam",Thumbnail="https://i.ytimg.com/vi/nx_LVO-j7Ds/mqdefault.jpg",VideoTitle="Naukar rocks mumma shocks😂 #shorts",ChannelTitle="Harsh Malhotra",VideoId="nx_LVO-j7Ds"}
             };
            var mockService = new Mock<IFavVideoService>();
            var mockService1 = new Mock<FavVideosContext>();

            mockService.Setup(svc => svc.GetFavVideoListOfUser(userId)).Throws(new Exception("No Favourites Available for This User"));
            var controller = new FavouriteVideosController(mockService.Object, mockService1.Object);
            controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext { User = user } };

            var actual = controller.GetVideosListOfUser(userId);
            Assert.IsInstanceOf<OkObjectResult>(actual);

        }

        [Test]
        public void PostShouldReturnCreated()
        {

            string userId = "sam";
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
             new Claim("userId", userId)
            }, "mock"));

            FavVideo favourite1 = new FavVideo { UserId = "sam", VideoId = "nx_LVO-j7Ds" };
            FavVideo favourite = new FavVideo { Id = 3, UserId = "sam", Thumbnail = "https://i.ytimg.com/vi/nx_LVO-j7Ds/mqdefault.jpg", VideoTitle = "Naukar rocks mumma shocks😂 #shorts", ChannelTitle = "Harsh Malhotra", VideoId = "nx_LVO-j7Ds" };
            //FavVideo favourite = new FavVideo { Id = 3, UserId = "sam", Thumbnail = "string.jpg", VideoTitle = "Naukar rocks ", ChannelTitle = "Harsh Malhotra", VideoId = "nx_LVO-j7Ds" };

            //List<FavVideo> favourites = new List<FavVideo>()
            //{
            // new FavVideo{Id=3,UserId="sam",Thumbnail="https://i.ytimg.com/vi/nx_LVO-j7Ds/mqdefault.jpg",VideoTitle="Naukar rocks mumma shocks😂 #shorts",ChannelTitle="Harsh Malhotra",VideoId="nx_LVO-j7Ds"}
            //};
            var mockService = new Mock<IFavVideoService>();
            var mockService1 = new Mock<FavVideosContext>();

            mockService.Setup(svc => svc.AddFavVideo(favourite1)).Returns(favourite);
            var controller = new FavouriteVideosController(mockService.Object, mockService1.Object);
            controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext { User = user } };

            var actual = controller.AddVideo(favourite1);
            Assert.IsInstanceOf<CreatedResult>(actual);
        }
        [Test]
        public void PostShouldReturnConflict()
        {

            string userId = "sam";
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
             new Claim("userId", userId)
            }, "mock"));

            FavVideo favourite = new FavVideo { Id = 3, UserId = "sam", Thumbnail = "https://i.ytimg.com/vi/nx_LVO-j7Ds/mqdefault.jpg", VideoTitle = "Naukar rocks mumma shocks😂 #shorts", ChannelTitle = "Harsh Malhotra", VideoId = "nx_LVO-j7Ds" };
            var mockService = new Mock<IFavVideoService>();
            var mockService1 = new Mock<FavVideosContext>();

            mockService.Setup(svc => svc.AddFavVideo(favourite)).Throws(new Exception("This Track Already Exist in Favourites"));
            var controller = new FavouriteVideosController(mockService.Object, mockService1.Object);
            controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext { User = user } };

            var actual = controller.AddVideo(favourite);
            Assert.IsInstanceOf<ConflictObjectResult>(actual);
        }

        [Test]
        public void RemoveShouldReturnOk()
        {

            string userId = "sam";
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
               new Claim("userId", userId)
            }, "mock"));

            FavVideo favourite = new FavVideo { Id = 3, UserId = "sam", Thumbnail = "https://i.ytimg.com/vi/nx_LVO-j7Ds/mqdefault.jpg", VideoTitle = "Naukar rocks mumma shocks😂 #shorts", ChannelTitle = "Harsh Malhotra", VideoId = "nx_LVO-j7Ds" };
            var mockService = new Mock<IFavVideoService>();
            var mockService1 = new Mock<FavVideosContext>();

            mockService.Setup(svc => svc.DeleteFavVideo(favourite)).Returns(favourite);
            var controller = new FavouriteVideosController(mockService.Object, mockService1.Object);
            controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext { User = user } };

            var actual = controller.Remove(favourite);
            Assert.IsInstanceOf<OkObjectResult>(actual);
        }

        [Test]
        public void RemoveShouldReturnNotFound()
        {

            string userId = "sam";
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
             new Claim("userId", userId)
            }, "mock"));

            FavVideo favourite = new FavVideo { Id = 3, UserId = "sam", Thumbnail = "https://i.ytimg.com/vi/nx_LVO-j7Ds/mqdefault.jpg", VideoTitle = "Naukar rocks mumma shocks😂 #shorts", ChannelTitle = "Harsh Malhotra", VideoId = "nx_LVO-j7Ds" };
            var mockService = new Mock<IFavVideoService>();
            var mockService1 = new Mock<FavVideosContext>();
            mockService.Setup(svc => svc.DeleteFavVideo(favourite)).Throws(new Exception("No Track Available to Remove"));
            var controller = new FavouriteVideosController(mockService.Object, mockService1.Object);
            controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext { User = user } };

            var actual = controller.Remove(favourite);
            Assert.IsInstanceOf<NotFoundObjectResult>(actual);
        }
    }
}
