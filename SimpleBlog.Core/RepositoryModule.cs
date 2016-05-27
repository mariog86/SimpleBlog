using Microsoft.Practices.Unity;
using SimpleBlog.Core.DAL;

namespace SimpleBlog.Core
{
    public class RepositoryModule : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IBlogContext>(new InjectionFactory(c => new BlogContext()));
        }
    }
}