using AutoMapper.QueryableExtensions;
using CheckMyCode.Data.Common.Repository;
using CheckMyCode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using CheckMyCode.Web.Areas.Projects.Models;

namespace CheckMyCode.Web.Areas.Projects.Controllers
{
    public class MyProjectsController : ProjectsBaseController
    {
        public MyProjectsController(IDeletableEntityRepository<Project> projects) : base(projects)
        {
        }

        // GET: Projects/MyProjects
        public ActionResult Index()
        {
            var currentUserId = User.Identity.GetUserId();
            var myProjects = this.Projects
                                 .All()
                                 .Where(p => p.OwnerId == currentUserId)
                                 .Project()
                                 .To<MyProjectsViewModel>();

            return View(myProjects);
        }
    }
}