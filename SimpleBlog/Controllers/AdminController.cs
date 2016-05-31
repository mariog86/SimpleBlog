using System.Web.Mvc;
using System.Web.Security;

using SimpleBlog.Models;
using SimpleBlog.Providers;

namespace SimpleBlog.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IAuthorizationProvider _authorizationProvider;

        public AdminController(IAuthorizationProvider authorizationProvider)
        {
            _authorizationProvider = authorizationProvider;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (_authorizationProvider.IsLoggedIn)
            {
                return RedirectToUrl(returnUrl);
            }

            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && _authorizationProvider.Login(model.UserName, model.Password))
            {
                return RedirectToUrl(returnUrl);
            }

            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Admin");

        }

        private ActionResult RedirectToUrl(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Manage");
            }
        }
    }
}