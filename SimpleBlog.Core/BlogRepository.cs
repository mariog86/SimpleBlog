using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SimpleBlog.Core.DAL;
using SimpleBlog.Core.Models;

using Z.EntityFramework.Plus;

namespace SimpleBlog.Core
{
    public class BlogRepository : IBlogRepository
    {
        // NHibernate object
        private readonly IBlogContext _dbContext;

        public BlogRepository(IBlogContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Post> Posts(int pageNo, int pageSize)
        {
            var posts = _dbContext.Set<Post>()
                                  .Where(p => p.Published)
                                  .OrderByDescending(p => p.PostedOn)
                                  .Skip(pageNo * pageSize)
                                  .Take(pageSize)
                                  .Include(p => p.Category)
                                  .ToList();

            var postIds = posts.Select(p => p.Id).ToList();

            return _dbContext.Set<Post>()
                  .Where(p => postIds.Contains(p.Id))
                  .OrderByDescending(p => p.PostedOn)
                  .Include(p => p.Tags)
                  .ToList();
        }

        public int TotalPosts()
        {
            return _dbContext.Set<Post>().Count(p => p.Published);
        }
        public IList<Post> PostsForCategory(string categorySlug, int pageNo, int pageSize)
        {
            var posts = _dbContext.Set<Post>()
                                .Where(p => p.Published && p.Category.UrlSlug.Equals(categorySlug))
                                .OrderByDescending(p => p.PostedOn)
                                .Skip(pageNo * pageSize)
                                .Take(pageSize)
                                .Include(p => p.Category)
                                .ToList();

            var postIds = posts.Select(p => p.Id).ToList();

            return _dbContext.Set<Post>()
                          .Where(p => postIds.Contains(p.Id))
                          .OrderByDescending(p => p.PostedOn)
                          .Include(p => p.Tags)
                          .ToList();
        }

        public int TotalPostsForCategory(string categorySlug)
        {
            return _dbContext.Set<Post>()
                        .Count(p => p.Published && p.Category.UrlSlug.Equals(categorySlug));
        }

        public Category Category(string categorySlug)
        {
            return _dbContext.Set<Category>()
                        .FirstOrDefault(t => t.UrlSlug.Equals(categorySlug));
        }

        public IList<Post> PostsForTag(string tagSlug, int pageNo, int pageSize)
        {
            var posts = _dbContext.Set<Post>()
                              .Where(p => p.Published && p.Tags.Any(t => t.UrlSlug.Equals(tagSlug)))
                              .OrderByDescending(p => p.PostedOn)
                              .Skip(pageNo * pageSize)
                              .Take(pageSize)
                              .Include(p => p.Category)
                              .ToList();

            var postIds = posts.Select(p => p.Id).ToList();

            return _dbContext.Set<Post>()
                          .Where(p => postIds.Contains(p.Id))
                          .OrderByDescending(p => p.PostedOn)
                          .Include(p => p.Tags)
                          .ToList();
        }

        public int TotalPostsForTag(string tagSlug)
        {
            return _dbContext.Set<Post>()
                        .Count(p => p.Published && p.Tags.Any(t => t.UrlSlug.Equals(tagSlug)));
        }

        public Tag Tag(string tagSlug)
        {
            return _dbContext.Set<Tag>()
                        .FirstOrDefault(t => t.UrlSlug.Equals(tagSlug));
        }

        public IList<Post> PostsForSearch(string search, int pageNo, int pageSize)
        {
            var posts = _dbContext.Set<Post>()
                                  .Where(p => p.Published && (p.Title.Contains(search) || p.Category.Name.Equals(search) || p.Tags.Any(t => t.Name.Equals(search))))
                                  .OrderByDescending(p => p.PostedOn)
                                  .Skip(pageNo * pageSize)
                                  .Take(pageSize)
                                  .Include(p => p.Category)
                                  .ToList();

            var postIds = posts.Select(p => p.Id).ToList();

            return _dbContext.Set<Post>()
                  .Where(p => postIds.Contains(p.Id))
                  .OrderByDescending(p => p.PostedOn)
                  .Include(p => p.Tags)
                  .ToList();
        }

        public int TotalPostsForSearch(string search)
        {
            return _dbContext.Set<Post>()
                    .Count(p => p.Published && (p.Title.Contains(search) || p.Category.Name.Equals(search) || p.Tags.Any(t => t.Name.Equals(search))));
        }

        public Post Post(int year, int month, string titleSlug)
        {
            var query = _dbContext.Set<Post>()
                                .Where(p => p.PostedOn.Year == year && p.PostedOn.Month == month && p.UrlSlug.Equals(titleSlug))
                                .Include(p => p.Category);

            query.Include(p => p.Tags).Future();

            return query.Future().Single();
        }

        public IList<Category> Categories()
        {
            return _dbContext.Set<Category>().OrderBy(p => p.Name).ToList();
        }
    }
}