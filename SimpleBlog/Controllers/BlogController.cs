using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleBlog.Core;
using SimpleBlog.Core.DAL;
using SimpleBlog.Models;

namespace SimpleBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;
        private readonly BlogContext _db = new BlogContext();

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public ViewResult Posts(int p = 1)
        {    
            // pick latest 10 posts
            var viewModel = new ListViewModel(_blogRepository, p);

            ViewBag.Title = "Latest Posts";
            return View("List", viewModel);
        }

        // GET: Blog
        public ActionResult Index(int? articleId, bool? forceReload)
        {
            ViewBag.Articles = _db.Articles.ToList();
            // WARNING!!! Insure that ViewBag.BlogPath terminates with a slash /
            ViewBag.BlogPath = "../blogFiles/";
            if (articleId != null)
            {
                ViewBag.currentArticle = articleId;
            }
            return View();
        }

        // GET: Blog/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Blog/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Blog/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
