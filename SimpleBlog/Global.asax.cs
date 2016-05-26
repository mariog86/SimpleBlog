using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using SimpleBlog.Core.Models;

namespace SimpleBlog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static ArticleRepository mainBlog;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            mainBlog = new ArticleRepository(@"C:\Users\magu\Documents\GitHub\SimpleBlog\SimpleBlog\blogFiles", "blog.dat");
        }
    }
}
