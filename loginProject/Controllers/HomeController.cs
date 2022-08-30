using loginProject.DB;
using loginProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace loginProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
      
        public ActionResult Login( loginclass obj)
        {
            RajaEntities entobj = new RajaEntities();
            var result = entobj.LgnTbls.Where(a => a.Email == obj.Email).FirstOrDefault();
            if (result == null)
            {
                TempData["email"] = "Invalid Email Pls Cheack Email :";
            }
            else
            {
                if (result.Email==obj.Email && result.Password == obj.Password)
                {
                    Session["e"]=result.Email;
                    return RedirectToAction("Index");
                }
                else{
                    TempData["pass"] = "Invalid PAssWord Or rong ";
                }
            }
            return View();
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