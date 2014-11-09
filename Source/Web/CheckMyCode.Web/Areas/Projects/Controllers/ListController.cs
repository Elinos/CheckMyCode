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
        public ListController(IRepository<Project> projects) : base(projects)
        {
        }

        // GET: Projects/List
        public ActionResult Index()
        {
            var projectsToList = this.Projects
                                     .All()
                                     .Where(p => p.IsPublic)
                                     .Project()
                                     .To<ListProjectsViewModel>();
            
            return View(projectsToList);
        }
    }
}