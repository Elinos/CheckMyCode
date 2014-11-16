using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using CheckMyCode.Data.Common.Repository;
using CheckMyCode.Data.Models;
using CheckMyCode.Web.Areas.Projects.Models;
using PagedList;

namespace CheckMyCode.Web.Areas.Projects.Controllers
{
    public class ListController : ProjectsBaseController
    {
        private const int ItemsPerPage = 3;
        
        public ListController(IDeletableEntityRepository<Project> projects) : base(projects)
        {
        }
        
        public ActionResult Index(string searchString, LanguageType? language, int? page)
        {
            var onePageofProjects = GetFilteredAndPagedList(searchString, language, page);
            
            return Request.IsAjaxRequest()
                   ? (ActionResult)PartialView("_ProjectListResult", onePageofProjects)
                   : View(onePageofProjects);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string searchString, LanguageType language, int? page)
        {
            var onePageofProjects = GetFilteredAndPagedList(searchString, language, page);
            return PartialView("_ProjectListResult", onePageofProjects);
        }

        private IPagedList<ListProjectsViewModel> GetFilteredAndPagedList(string searchString, LanguageType? language, int? page)
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
            var onePageofProjects = result.ToPagedList(pageNumber, ItemsPerPage);
            ViewBag.searchString = searchString;
            ViewBag.language = language;
            return onePageofProjects;
        }
    }
}