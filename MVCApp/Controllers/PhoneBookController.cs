using System.Collections.Generic;
using System.Web.Mvc;
using Repositories;
using Models;

namespace MVCApp.Controllers
{
    public class PhoneBookController : Controller
    {

        public ActionResult getContacts()
        {
            Repository _rep = new Repository();
            List<Contact> contacts = _rep.getContacts();

            return Json(contacts, JsonRequestBehavior.AllowGet);
        }
    }
}