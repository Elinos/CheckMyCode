using CheckMyCode.Data.Common.Repository;
using CheckMyCode.Data.Models;
using CheckMyCode.Web.ViewModels.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Ionic.Zip;
using System.IO;

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

            if (model.File.ContentType != "application/zip" && model.File.ContentType != "application/x-zip-compressed")
            {
                ModelState.AddModelError("File", "You must upload zip file!");
                return View(model);
            }
            using (ZipFile zip = ZipFile.Read(model.File.InputStream))
            {
                foreach (ZipEntry f in zip)
                {
                    using (var ms = new MemoryStream())
                    {
                        f.Extract(ms);
                        byte[] content = ms.ToArray();
                        var file = new CheckMyCode.Data.Models.File()
                        {
                            Content = content,
                            LanguageType = model.LanguageType,
                            Filename = f.FileName
                        };
                        projectToAdd.Files.Add(file);
                    }
                }
            }
            
            projects.Add(projectToAdd);
            projects.SaveChanges();

            return RedirectToAction("Create");
        }
    }
}