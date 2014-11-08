using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckMyCode.Web.Areas.Projects.Controllers
{
    public class ListController : Controller
    {
        // GET: Projects/List
        public ActionResult Index()
        {
            return View();
        }
    }
}