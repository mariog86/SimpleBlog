using System.Collections.Generic;
using SimpleBlog.Core.Models;

namespace SimpleBlog.Core
{

    public interface IBlogRepository
    {
        IList<Post> Posts(int pageNo, int pageSize);
        int TotalPosts();
    }
}