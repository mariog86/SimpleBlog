using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SimpleBlog.Core.DAL;
using SimpleBlog.Core.Models;

namespace SimpleBlog.Core
{
    public class BlogRepository : IBlogRepository
    {
        // NHibernate object
        private readonly BlogContext _dbContext;

        public BlogRepository(BlogContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Post> Posts(int pageNo, int pageSize)
        {
            var posts = _dbContext.Posts
                .Where(p => p.Published)
                .OrderByDescending(p => p.PostedOn)
                .Skip(pageNo*pageSize)
                .Take(pageSize)
                .Include(p => p.Category)
                .ToList();

            var postIds = posts.Select(p => p.Id).ToList();

            return _dbContext.Posts
                  .Where(p => postIds.Contains(p.Id))
                  .OrderByDescending(p => p.PostedOn)
                  .Include(p => p.Tags)
                  .ToList();
        }

        public int TotalPosts()
        {
            return _dbContext.Posts.Count(p => p.Published);
        }
    }
}