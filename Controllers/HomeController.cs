using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travelo.Models;
namespace Travelo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Home()
        {
           
            return View();
        }
       

        // GET About_US
        public ActionResult About_US()
        {

            return View();
        }
        // GET Our_Team
        public ActionResult Our_Team()
        {

            return View();
        }

      
    }
}