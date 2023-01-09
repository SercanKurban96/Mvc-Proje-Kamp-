using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A_MvcProKamp_UI.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFileManagerBL ifm = new ImageFileManagerBL(new EfImageFileDAL());
        public ActionResult Index()
        {
            var files = ifm.GetList();
            return View(files);
        }
    }
}