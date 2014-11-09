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
using PagedList;

namespace CheckMyCode.Web.Areas.Projects.Controllers
{
    public class MyProjectsController : ProjectsBaseController
    {
        public MyProjectsController(IDeletableEntityRepository<Project> projects) : base(projects)
        {
        }

        // GET: Projects/MyProjects
        public ActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            var currentUserId = User.Identity.GetUserId();
            var myProjects = this.Projects
                                 .All()
                                 .Where(p => p.OwnerId == currentUserId)
                                 .OrderByDescending(p => p.CreatedOn)
                                 .Project()
                                 .To<MyProjectsViewModel>();

            var onePageofProjects = myProjects.ToPagedList(pageNumber, 3);
            return Request.IsAjaxRequest()
                   ? (ActionResult)PartialView("_MyProjectsList", onePageofProjects)
                   : View(onePageofProjects);
        }
    }
}