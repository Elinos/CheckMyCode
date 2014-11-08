using CheckMyCode.Data;
using CheckMyCode.Data.Common.Repository;
using CheckMyCode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using CheckMyCode.Web.ViewModels.Home;

namespace CheckMyCode.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Project> projects;

        public HomeController(IRepository<Project> projects)
        {
            this.projects = projects;
        }

        public ActionResult Index()
        {
            var projects = this.projects.All().Project().To<IndexProjectsViewModel>();

            return View(projects);
        }
    }
}