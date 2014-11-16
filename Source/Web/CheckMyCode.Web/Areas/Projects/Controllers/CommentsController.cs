using AutoMapper;
using AutoMapper.QueryableExtensions;
using CheckMyCode.Data.Models;
using CheckMyCode.Web.Areas.Projects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using CheckMyCode.Data.Common.Repository;

namespace CheckMyCode.Web.Areas.Projects.Controllers
{
    public class CommentsController : CommentsBaseController
    {
        public CommentsController(IDeletableEntityRepository<Comment> comments, IDeletableEntityRepository<Project> projects) : base(comments, projects)
        {
        }

        [ChildActionOnly]
        public ActionResult ListComments(int projectId)
        {
            var comments = this.Comments
                               .All()
                               .Where(c => c.ProjectId == projectId)
                               .OrderByDescending(c => c.CreatedOn)
                               .Take(10)
                               .Project()
                               .To<CommentViewModel>();

            return View(comments);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(AddCommentViewModel comment)
        {
            if (comment != null && ModelState.IsValid)
            {
                var dbComment = new Comment()
                {
                    Text = comment.Text,
                };
                dbComment.AuthorId = this.User.Identity.GetUserId();
                var project = this.Projects.GetById(comment.ProjectId);
                if (project == null)
                {
                    throw new HttpException(404, "Project not found");
                }

                project.Comments.Add(dbComment);
                this.Projects.SaveChanges();

                var viewModel = Mapper.Map<CommentViewModel>(dbComment);
                viewModel.AuthorName = this.User.Identity.Name;

                return PartialView("_CommentPartial", viewModel);
            }

            throw new HttpException(400, "Invalid comment");
        }
    }
}