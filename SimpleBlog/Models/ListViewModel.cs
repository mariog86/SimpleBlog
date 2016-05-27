﻿using System.Collections.Generic;
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

        public ListViewModel(IBlogRepository blogRepository, string categorySlug, int p)
        {
            Posts = blogRepository.PostsForCategory(categorySlug, p - 1, 10);
            TotalPosts = blogRepository.TotalPostsForCategory(categorySlug);
            Category = blogRepository.Category(categorySlug);
        }

        public IList<Post> Posts { get; private set; }

        public int TotalPosts { get; private set; }

        public Category Category { get; private set; }
    }
}
