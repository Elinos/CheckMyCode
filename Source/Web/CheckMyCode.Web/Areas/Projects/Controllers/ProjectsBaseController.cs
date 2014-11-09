using CheckMyCode.Data.Common.Repository;
using CheckMyCode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace CheckMyCode.Web.Areas.Projects.Controllers
{
    [Authorize]
    public abstract class ProjectsBaseController : Controller
    {
        protected IDeletableEntityRepository<Project> Projects { get; set; }

        public ProjectsBaseController(IDeletableEntityRepository<Project> projects)
        {
            this.Projects = projects;
        }
    }
}