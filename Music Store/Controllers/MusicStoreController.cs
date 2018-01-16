using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music_Store.Controllers
{
    public class MusicStoreController : Controller
    {
        // GET: MusicStore
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Browse(string Name)
        {
            ViewBag.Name = Name;
            return View("Browse");
        }

        public ActionResult Details(int? id)
        {
            ViewBag.id = id;
            return View("Details");
        }

       
    }
}