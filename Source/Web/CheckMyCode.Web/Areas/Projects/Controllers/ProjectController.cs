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
    [Authorize]
    public class ProjectController : ProjectsBaseController
    {
        public IDeletableEntityRepository<File> FilesRepo { get; set; }

        public IDeletableEntityRepository<FileRevision> RevisionsRepo { get; set; }

        public ProjectController(IDeletableEntityRepository<Project> projects,
            IDeletableEntityRepository<File> files, IDeletableEntityRepository<FileRevision> revisions) : base(projects)
        {
            this.FilesRepo = files;
            this.RevisionsRepo = revisions;
        }

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
                this.TempData["successMessage"] = "File revision added!";
                return RedirectToAction("Files", new { id = file.ProjectId, fileId = model.FileId });
            }

            return View(model);
        }

        public ActionResult Download(int id) 
        {
            var file = this.FilesRepo.All().Where(f => f.Id == id).FirstOrDefault();
            var contents = file.Content;
            return File(contents, "text/plain", file.Filename);
        }

        public ActionResult DownloadRevision(int revisionId)
        {
            var file = this.RevisionsRepo.All().Where(r => r.Id == revisionId).FirstOrDefault();
            var contents = file.ChangedFile;
            return File(contents, "text/plain", file.File.Filename);
        }
    }
}