using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using CheckMyCode.Data.Common.Repository;
using CheckMyCode.Data.Models;
using CheckMyCode.Web.Areas.Administration.Models;
using CheckMyCode.Web.Areas.Projects.Controllers;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity;

namespace CheckMyCode.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProjectsController : ProjectsBaseController
    {
        public ProjectsController(IDeletableEntityRepository<Project> projects) : base(projects)
        {
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CreateProject([DataSourceRequest]
                                        DataSourceRequest request, ProjectsAdministrationViewModel project)
        {
            if (project != null && ModelState.IsValid)
            {
                var newProject = new Project
                {
                    Name = project.Name,
                    OwnerId = this.User.Identity.GetUserId(),
                    IsPublic = project.IsPublic,
                };

                this.Projects.Add(newProject);
                this.Projects.SaveChanges();

                project.Id = newProject.Id;
            }

            return Json(new[] { project }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ReadProjects([DataSourceRequest]
                                       DataSourceRequest request)
        {
            var result = this.Projects.All().Project().To<ProjectsAdministrationViewModel>();

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateProject([DataSourceRequest]
                                        DataSourceRequest request, ProjectsAdministrationViewModel project)
        {
            var existingProject = this.Projects.All().FirstOrDefault(x => x.Id == project.Id);

            if (existingProject != null && ModelState.IsValid)
            {
                existingProject.Name = project.Name;
                existingProject.IsPublic = project.IsPublic;
                this.Projects.SaveChanges();
            }

            return Json((new[] { project }.ToDataSourceResult(request, ModelState)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteProject([DataSourceRequest]
                                        DataSourceRequest request, ProjectsAdministrationViewModel project)
        {
            var existingProject = this.Projects.All().FirstOrDefault(x => x.Id == project.Id);

            this.Projects.Delete(existingProject);
            this.Projects.SaveChanges();
            
            return Json(new[] { project }, JsonRequestBehavior.AllowGet);
        }
    }
}