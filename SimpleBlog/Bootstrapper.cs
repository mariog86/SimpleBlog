using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using SimpleBlog.Core;
using SimpleBlog.Providers;

namespace SimpleBlog
{
    public class Bootstrapper
    {
        public static IUnityContainer Initialize()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.AddNewExtension<RepositoryModule>();

            // register all your components with the container here  
            //This is the important line to edit  
            container.RegisterType<IBlogRepository, BlogRepository>();
            container.RegisterType<IAuthorizationProvider, AuthorizationProvider>();
            
            return container;
        }
    }
}