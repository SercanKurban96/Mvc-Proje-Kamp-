using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A_MvcProKamp_UI.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManagerBL cm = new ContactManagerBL(new EfContactDAL());
        MessageManagerBL mm = new MessageManagerBL(new EfMessageDAL());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetByID(id);
            return View(contactvalues);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

		public PartialViewResult ContactPartialLeftMenu()
		{
			StaticModel model = new StaticModel();
			//model.InboxCount = mm.GetListInbox().Count();
			//model.SendboxCount = mm.GetListSendbox().Count();
			model.ReadSendboxCount = mm.GetListInbox(true, "admin@gmail.com").Count();
			model.UnreadableSendboxCount = mm.GetListInbox(false, "admin@gmail.com").Count();
			return PartialView(model);
		}
	}
}