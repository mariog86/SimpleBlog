using System.Collections.Generic;
using System.Linq;
using SimpleBlog.Core.DAL;

namespace SimpleBlog.Core.Models
{
    public class ArticleRepository : List<Article>
    {
        private BlogContext _db = new BlogContext();

        public ArticleRepository()
        {
            GetAllBlogArticles(false);
        }

        public void GetAllBlogArticles(bool? forceReload)
        {
            if (Count == 0 || (forceReload == true))
            {
                Clear();
                LoadBlogArticlesFromDataStore();
            }
        }

        private void LoadBlogArticlesFromDataStore()
        {
            AddRange(_db.Articles.ToList());
        }

    }
}