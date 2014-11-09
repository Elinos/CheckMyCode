using AutoMapper.QueryableExtensions;
using CheckMyCode.Data.Common.Repository;
using CheckMyCode.Data.Models;
using CheckMyCode.Web.Areas.Projects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckMyCode.Web.Areas.Projects.Controllers
{
    public class ProjectController : ProjectsBaseController
    {
        public ProjectController(IDeletableEntityRepository<Project> projects) : base(projects)
        {
        }

        // GET: Projects/Project
        public ActionResult Index(int id)
        {
            var project = this.Projects
                              .All()
                              .Where(p => p.Id == id)
                              .Project()
                              .To<ProjectViewModel>()
                              .FirstOrDefault();

            return View(project);
        }
    }
}