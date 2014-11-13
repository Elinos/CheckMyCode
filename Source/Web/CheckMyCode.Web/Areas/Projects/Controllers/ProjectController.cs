using AutoMapper.QueryableExtensions;
using AutoMapper.QueryableExtensions;
using CheckMyCode.Data.Common.Repository;
using CheckMyCode.Data.Models;
using CheckMyCode.Web.Areas.Projects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace CheckMyCode.Web.Areas.Projects.Controllers
{
    public class ProjectController : ProjectsBaseController
    {
        public IDeletableEntityRepository<File> FilesRepo { get; set; }

        public ProjectController(IDeletableEntityRepository<Project> projects,
            IDeletableEntityRepository<File> files) : base(projects)
        {
            this.FilesRepo = files;
        }

        //[OutputCache(Duration = 10 * 60)]
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

        //[OutputCache(Duration = 10 * 60)]
        public ActionResult Files(int id, int fileId)
        {
            var project = this.Projects.All().FirstOrDefault(p => p.Id == id);
            if (project == null)
            {
                return HttpNotFound();
            }

            var file = project.Files.FirstOrDefault(f => f.Id == fileId);

            if (file == null)
            {
                return HttpNotFound();
            }
            var model = new FilesViewModel();
            AutoMapper.Mapper.Map(file, model);

            return View(model);
        }

        public ActionResult EditFile(int fileId)
        {
            var file = this.FilesRepo.All().FirstOrDefault(f => f.Id == fileId);

            if (file == null)
            {
                return HttpNotFound();
            }

            var model = new EditFileViewModel();
            AutoMapper.Mapper.Map(file, model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public ActionResult EditFile(EditFileViewModel model)
        {
            var file = FilesRepo.GetById(model.FileId);
            if (file != null && ModelState.IsValid)
            {
                var fileRevision = new FileRevision()
                {
                    ChangedFile = Encoding.Default.GetBytes(model.FileAsString),
                    AuthorId = User.Identity.GetUserId(),
                    Comment = model.Comment
                };
                
                file.FileRevisions.Add(fileRevision);
                FilesRepo.SaveChanges();
                return RedirectToAction("Files", new { id = file.ProjectId, fileId = model.FileId });
            }

            return View(model);
        }
    }
}