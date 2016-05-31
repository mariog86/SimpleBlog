using System.Web;

using static System.Web.Security.FormsAuthentication;

namespace SimpleBlog.Providers
{
    public class AuthorizationProvider : IAuthorizationProvider
    {
        public bool IsLoggedIn => HttpContext.Current.User.Identity.IsAuthenticated;

        public bool Login(string userName, string password)
        {
            bool result = Authenticate(userName, password);

            if (result)
            {
                SetAuthCookie(userName, false);
            }

            return result;
        }

        public void Logout()
        {
            SignOut();
        }
    }
}