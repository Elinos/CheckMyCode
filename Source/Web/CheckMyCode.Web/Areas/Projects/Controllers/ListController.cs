using AutoMapper.QueryableExtensions;
using CheckMyCode.Data.Common.Repository;
using CheckMyCode.Data.Models;
using CheckMyCode.Web.Areas.Projects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace CheckMyCode.Web.Areas.Projects.Controllers
{
    public class ListController : ProjectsBaseController
    {
        public ListController(IDeletableEntityRepository<Project> projects) : base(projects)
        {
        }
        
        // GET: Projects/List
        public ActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            var projectsToList = this.Projects
                                     .All()
                                     .Where(p => p.IsPublic)
                                     .OrderByDescending(p => p.CreatedOn)
                                     .Project().To<ListProjectsViewModel>();

            var onePageofProjects = projectsToList.ToPagedList(pageNumber, 2);

            return Request.IsAjaxRequest()
                   ? (ActionResult)PartialView("_ProjectListResult", onePageofProjects)
                   : View(onePageofProjects);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string searchString, LanguageType language, int? page)
        {
            var result = this.Projects
                             .All()
                             .Where(p => p.IsPublic)
                             .OrderByDescending(p => p.CreatedOn)
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
            var pageNumber = page ?? 1;
            var onePageofProjects = result.ToPagedList(pageNumber, 2);
            return PartialView("_ProjectListResult", onePageofProjects);
        }
    }
}