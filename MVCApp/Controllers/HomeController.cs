using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositories;
using Models;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Repository _rep = new Repository();
            List<Contact> contacts = _rep.getContacts();

            return View(contacts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
           

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}