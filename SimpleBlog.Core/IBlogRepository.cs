using System.Collections.Generic;
using SimpleBlog.Core.Models;

namespace SimpleBlog.Core
{

    public interface IBlogRepository
    {
        IList<Post> Posts(int pageNo, int pageSize);
        int TotalPosts();
        IList<Post> PostsForCategory(string categorySlug, int pageNo, int pageSize);
        int TotalPostsForCategory(string categorySlug);
        Category Category(string categorySlug);
    }
}