using System.Collections.Generic;
using System.Web.Mvc;
using Repositories;
using Models;
using Services;

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
        public ActionResult saveContact(Contact model)
        {
            Service _service = new Service();
            var result = _service.saveContacts(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}