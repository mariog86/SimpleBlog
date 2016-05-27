using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleBlog.Core;
using SimpleBlog.Models;

namespace SimpleBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public ViewResult Posts(int p = 1)
        {    
            var viewModel = new ListViewModel(_blogRepository, p);

            ViewBag.Title = "Latest Posts";
            return View("List", viewModel);
        }

        public ViewResult Category(string category, int p = 1)
        {
            var viewModel = new ListViewModel(_blogRepository, category, p);

            if (viewModel.Category == null)
            {
                throw new HttpException(404, "Category not found");
            }

            ViewBag.Title = $@"Latest posts on category ""{viewModel.Category.Name}""";
            return View("List", viewModel);
        }
    }
}
