using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using NUnit.Framework;

using Rhino.Mocks;

using SimpleBlog.Controllers;
using SimpleBlog.Models;
using SimpleBlog.Providers;

namespace SimpleBlog.Tests
{
    [TestFixture]
    public class AdminControllerTests
    {
        private AdminController _adminController;
        private IAuthorizationProvider _authorizationProvider;

        [SetUp]
        public void SetUp()
        {
            _authorizationProvider = MockRepository.GenerateMock<IAuthorizationProvider>();
            _adminController = new AdminController(_authorizationProvider);

            HttpContextBase httpContextMock = MockRepository.GenerateMock<HttpContextBase>();
            _adminController.Url = new UrlHelper(new RequestContext(httpContextMock, new RouteData()));
        }

        [Test]
        public void Login_IsLoggedIn_True_Test()
        {
            // arrange
            _authorizationProvider.Stub(s => s.IsLoggedIn).Return(true);

            // act
            ActionResult actual = _adminController.Login("/admin/manage");

            // assert
            Assert.IsInstanceOf<RedirectResult>(actual);
            Assert.AreEqual("/admin/manage", ((RedirectResult)actual).Url);
        }

        [Test]
        public void Login_IsLoggedIn_False_Test()
        {
            // arrange
            _authorizationProvider.Stub(s => s.IsLoggedIn).Return(false);

            // act
            ActionResult actual = _adminController.Login("/");

            // assert
            Assert.IsInstanceOf<ViewResult>(actual);
            Assert.AreEqual("/", ((ViewResult)actual).ViewBag.ReturnUrl);
        }

        [Test]
        public void Login_Post_Model_Invalid_Test()
        {
            // arrange
            LoginModel model = new LoginModel();
            _adminController.ModelState.AddModelError("UserName", "UserName is required");

            // act
            ActionResult actual = _adminController.Login(model, "/");

            // assert
            Assert.IsInstanceOf<ViewResult>(actual);
        }

        [Test]
        public void Login_Post_User_Invalid_Test()
        {
            // arrange
            LoginModel model = new LoginModel
            {
                UserName = "invaliduser",
                Password = "password"
            };
            _authorizationProvider.Stub(s => s.Login(model.UserName, model.Password))
                         .Return(false);

            // act
            ActionResult actual = _adminController.Login(model, "/");

            // assert
            Assert.IsInstanceOf<ViewResult>(actual);
            ModelErrorCollection modelStateErrors = _adminController.ModelState[""].Errors;
            Assert.IsTrue(modelStateErrors.Count > 0);
            Assert.AreEqual("The user name or password provided is incorrect.",
                modelStateErrors[0].ErrorMessage);
        }

        [Test]
        public void Login_Post_User_Valid_Test()
        {
            // arrange
            LoginModel model = new LoginModel
            {
                UserName = "validuser",
                Password = "password"
            };
            _authorizationProvider.Stub(s => s.Login(model.UserName, model.Password))
                         .Return(true);

            // act
            var actual = _adminController.Login(model, "/");

            // assert
            Assert.IsInstanceOf<RedirectResult>(actual);
            Assert.AreEqual("/", ((RedirectResult)actual).Url);
        }
    }
}
