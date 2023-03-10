using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer;

namespace A_MvcProKamp_UI.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        HeadingManagerBL hm = new HeadingManagerBL(new EfHeadingDAL());
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents(DateTime start, DateTime end)
        {
            var viewModel = new Calender();
            var events = new List<Calender>();
            start = DateTime.Today.AddDays(-14);
            end = DateTime.Today.AddDays(-14);

            foreach (var item in hm.GetList())
            {
                events.Add(new Calender()
                {
                    title = item.HeadingName,
                    start = item.HeadingDate,
                    end = item.HeadingDate.AddDays(-14),
                    allDay = false
                });

                start = start.AddDays(7);
                end = end.AddDays(7);
            }
            return Json(events.ToArray(), JsonRequestBehavior.AllowGet);
        }
    }
}