using CheckMyCode.Data.Common.Repository;
using CheckMyCode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckMyCode.Web.Areas.Projects.Controllers
{
    [Authorize]
    public abstract class CommentsBaseController : Controller
    {
        public CommentsBaseController(IDeletableEntityRepository<Comment> comments, IDeletableEntityRepository<Project> projects)
        {
            this.Comments = comments;
            this.Projects = projects;
        }

        protected IDeletableEntityRepository<Comment> Comments { get; set; }

        protected IDeletableEntityRepository<Project> Projects { get; set; }
    }
}