using AutoMapper.QueryableExtensions;
using CheckMyCode.Data.Common.Repository;
using CheckMyCode.Data.Models;
using CheckMyCode.Web.ViewModels.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckMyCode.Web.Areas.Projects.Controllers
{
    public class ListController : ProjectsBaseController
    {
        public ListController(IDeletableEntityRepository<Project> projects)
            : base(projects)
        {
        }

        // GET: Projects/List
        public ActionResult Index()
        {
            var projectsToList = this.Projects
                                     .All()
                                     .Where(p => p.IsPublic)
                                     .Project().To<ListProjectsViewModel>();
            
            return View(projectsToList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string searchString, LanguageType language)
        {
            var result = this.Projects
                             .All()
                             .Where(p => p.IsPublic)
                             .Project()
                             .To<ListProjectsViewModel>();
            
            if (searchString != String.Empty && searchString != null)
            {
                result = result
                               .Where(p => p.Name.ToLower().Contains(searchString.ToLower()) ||
                                           p.OwnerUserName.ToLower().Contains(searchString.ToLower()));
            }

            if (language != null && language.ToString() != "All")
            {
                result = result.Where(p => p.Language == language);
            }
            return PartialView("_ProjectListResult", result);
        }
    }
}