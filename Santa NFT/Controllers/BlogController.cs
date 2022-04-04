using Santa_NFT.Models;
using Santa_NFT.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Santa_NFT.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            BlogRepository repo = new BlogRepository();
            ViewBag.BlogCategoryCount = repo.GetBlogCategoryCount();
            return View(repo.GetAll());
        }
        public ActionResult ListAll()
        {
            BlogRepository repo = new BlogRepository();
            return View(repo.GetAll());
        }

        public ActionResult Create(string id)
        {

            Blog obj = new Blog();
           
            if (!string.IsNullOrEmpty(id))
            {
                BlogRepository repo = new BlogRepository();
                obj = repo.Get(Convert.ToInt32(id));
            }

            ViewBag.BlogCategory = new BlogCategoryRepository().GetAll();
            return View(obj);
        }
        public ActionResult SaveData(Blog obj)
        {
            return Json(new BlogRepository().AddOrUpdate(obj));
        }
        public ActionResult DeleteData(Blog obj)
        {
            return Json(new BlogRepository().Delete(obj));
        }
        public ActionResult Details(string id)
        {
            BlogRepository repo = new BlogRepository();
            ViewBag.BlogCategoryCount = repo.GetBlogCategoryCount();
            return View(repo.Get(Convert.ToInt32(id)));
        }
    }
}