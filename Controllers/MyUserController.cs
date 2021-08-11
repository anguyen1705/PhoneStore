using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneStore.Models;
using System.Web.Security;

namespace PhoneStore.Controllers
{
    public class MyUserController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        
        //logout
        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            /*  Session.Clear();*/
            return RedirectToAction("Index", "Home");
        }
    }
}