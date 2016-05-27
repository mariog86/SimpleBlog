using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBlog.Core;
using SimpleBlog.Core.Models;

namespace SimpleBlog.Models
{
    public class ListViewModel
    {
        public ListViewModel(IBlogRepository blogRepository, int p)
        {
            Posts = blogRepository.Posts(p - 1, 10);
            TotalPosts = blogRepository.TotalPosts();
        }

        public IList<Post> Posts { get; private set; }
        public int TotalPosts { get; private set; }
    }
}
