using CheckMyCode.Data;
using CheckMyCode.Data.Common.Repository;
using CheckMyCode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using CheckMyCode.Web.ViewModels.Projects;

namespace CheckMyCode.Web.Controllers
{
    public class HomeController : Controller
    {
        private IDeletableEntityRepository<Project> projects;

        public HomeController(IDeletableEntityRepository<Project> projects)
        {
            this.projects = projects;
        }

        public ActionResult Index()
        {
            var projects = this.projects
                               .All()
                               .Where(p => p.IsPublic)
                               .OrderByDescending(p => p.CreatedOn)
                               .Take(10)
                               .Project()
                               .To<ListProjectsViewModel>();

            return View(projects);
        }

        public ActionResult ChangeLanguage(string language)
        {
            var projects = this.projects
                               .All()
                               .Where(p => p.IsPublic)
                               .OrderByDescending(p => p.CreatedOn)
                               .Take(10)
                               .Project()
                               .To<ListProjectsViewModel>();
            if (language != String.Empty && language != "All")
            {
                projects = projects.Where(p => p.Language.ToString() == language);
            }

            return PartialView("_TopTenProjectListResult", projects);
        }
    }
}