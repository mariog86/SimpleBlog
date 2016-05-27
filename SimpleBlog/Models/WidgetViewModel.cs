using System.Collections.Generic;

using SimpleBlog.Core;
using SimpleBlog.Core.Models;

namespace SimpleBlog.Models
{
    public class WidgetViewModel
    {
        public WidgetViewModel(IBlogRepository blogRepository)
        {
            Categories = blogRepository.Categories();
        }

        public IList<Category> Categories { get; private set; }
    }
}