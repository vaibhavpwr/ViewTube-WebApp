using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    class UserTest
    {
        [Test]
        public void RegisterShouldReturnCreated()
        {
            User user = new User { UserId = "sam", Email = "sam@gmail.com", Password = "sam@1234" };
            var mockService = new Mock<IAuthService>();
            mockService.Setup(svc => svc.RegisterUser(user)).Returns((true));
            var controller = new AuthController(mockService.Object);

            var actual = controller.Register(user);
            Assert.IsInstanceOf<CreatedResult>(actual);

        }

        [Test]
        public void RegisterShouldReturnConflict()
        {
            User user = new User { UserId = "sam", Email = "sam@gmail.com", Password = "sam@1234" };
            var mockService = new Mock<IAuthService>();
            mockService.Setup(svc => svc.RegisterUser(user)).Throws(new UserAlreadyExistsException("User Already Exist with this mail ID"));
            var controller = new AuthController(mockService.Object);

            var actual = controller.Register(user);
            Assert.IsInstanceOf<ConflictObjectResult>(actual);

        }

        [Test]
        public void LoginShouldSucess()
        {
            User user = new User { UserId = "sam", Password = "sam@1234" };
            var mockService = new Mock<IAuthService>();
            mockService.Setup(svc => svc.LoginUser(user)).Returns((true));
            var controller = new AuthController(mockService.Object);

            var actual = controller.Login(user);
            Assert.IsInstanceOf<OkObjectResult>(actual);

        }

        [Test]
        public void LoginShouldReject()
        {
            User user = new User { UserId = "sam", Password = "sam@1234" };
            var mockService = new Mock<IAuthService>();
            mockService.Setup(svc => svc.LoginUser(user)).Throws(new UnauthorizedAccessException("Invalid Email or Password"));
            var controller = new AuthController(mockService.Object);

            var actual = controller.Login(user);
            Assert.IsInstanceOf<UnauthorizedObjectResult>(actual);

        }
    }
}
