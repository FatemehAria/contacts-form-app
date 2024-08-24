using System.Collections.Generic;
using System.Web.Mvc;
using Repositories;
using Models;
using Services;

namespace MVCApp.Controllers
{
    public class PhoneBookController : Controller
    {
        Service _service = new Service();

        public ActionResult getContacts()
        {
            Repository _rep = new Repository();
            List<Contact> contacts = _rep.getContacts();

            return Json(contacts, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getContactById(string id)
        {
            Repository _rep = new Repository();
            Contact contacts = _service.getContactById(id);

            return Json(contacts, JsonRequestBehavior.AllowGet);
        }

        public ActionResult saveContact(Contact model)
        {
            
            var result = _service.saveContacts(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}