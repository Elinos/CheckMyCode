using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using CheckMyCode.Data.Common.Repository;
using CheckMyCode.Data.Models;
using CheckMyCode.Web.Areas.Projects.Models;
using System.Web.Caching;
using System.Collections.Generic;

namespace CheckMyCode.Web.Controllers
{
    public class HomeController : Controller
    {
        private const int NumberOfProjects = 10;
        private readonly IDeletableEntityRepository<Project> projects;

        public HomeController(IDeletableEntityRepository<Project> projects)
        {
            this.projects = projects;
        }
        
        public ActionResult Index()
        {
            var projects = GetAllProjectsFromCache();

            return View(projects);
        }

        public ActionResult ChangeLanguage(string language)
        {
            var projects = GetAllProjectsFromCache();
            
            if (language != String.Empty && language != "All")
            {
                projects = projects.Where(p => p.Language.ToString() == language);
            }
            
            return PartialView("_TopTenProjectListResult", projects);
        }
        
        private IEnumerable<ListProjectsViewModel> GetAllProjectsFromCache()
        {
            if (this.HttpContext.Cache["projects"] == null)
            {
                var projects = this.projects
                                   .All()
                                   .Where(p => p.IsPublic)
                                   .OrderByDescending(p => p.CreatedOn)
                                   .Take(NumberOfProjects)
                                   .Project()
                                   .To<ListProjectsViewModel>();
                this.HttpContext.Cache.Add("projects", projects.ToList(), null, DateTime.Now.AddHours(1), TimeSpan.Zero, CacheItemPriority.Default, null);
            }

            return this.HttpContext.Cache["projects"] as IEnumerable<ListProjectsViewModel>;
        }
    }
}