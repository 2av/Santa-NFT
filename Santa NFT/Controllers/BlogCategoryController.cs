using Santa_NFT.Models;
using Santa_NFT.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Santa_NFT.Controllers
{
    public class BlogCategoryController : Controller
    {
        public ActionResult Index()
        {
            BlogCategoryRepository repo = new BlogCategoryRepository();
            return View(repo.GetAll());
        }
        public ActionResult Create(string id)
        {

            BlogCategory obj = new BlogCategory();

            if (!string.IsNullOrEmpty(id))
            {
                BlogCategoryRepository repo = new BlogCategoryRepository();
                obj = repo.Get(Convert.ToInt32(id));
            }
            return View(obj);
        }
        public ActionResult SaveData(BlogCategory obj)
        {
            return Json(new BlogCategoryRepository().AddOrUpdate(obj));
        }
        public ActionResult DeleteData(BlogCategory obj)
        {
            return Json(new BlogCategoryRepository().Delete(obj));
        } 
    }
}