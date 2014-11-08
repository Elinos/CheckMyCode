using CheckMyCode.Data.Common.Repository;
using CheckMyCode.Data.Models;
using CheckMyCode.Web.ViewModels.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace CheckMyCode.Web.Areas.Projects.Controllers
{
    public class ManagementController : Controller
    {
        private IRepository<Project> projects;

        public ManagementController(IRepository<Project> projects)
        {
            this.projects = projects;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateProjectViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var projectToAdd = new Project();

            projectToAdd.Name = model.Name;
            projectToAdd.OwnerId = User.Identity.GetUserId();
            projectToAdd.IsPublic = model.IsPublic;
            if (Request.Files.Count > 0)
            {
                byte[] uploadedFile = new byte[model.File.InputStream.Length];
                model.File.InputStream.Read(uploadedFile, 0, uploadedFile.Length);
                var file = new File()
                {
                    Content = uploadedFile,
                    LanguageType = model.LanguageType,
                    Filename = model.File.FileName
                };
                
                projectToAdd.Files.Add(file);
            }

            projects.Add(projectToAdd);
            projects.SaveChanges();

            return RedirectToAction("Create");
        }
    }
}