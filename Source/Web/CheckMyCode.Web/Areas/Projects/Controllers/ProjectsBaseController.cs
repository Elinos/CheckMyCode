using CheckMyCode.Data.Common.Repository;
using CheckMyCode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace CheckMyCode.Web.Areas.Projects.Controllers
{
    public abstract class ProjectsBaseController : Controller
    {
        protected IRepository<Project> Projects { get; set; }

        public ProjectsBaseController(IRepository<Project> projects)
        {
            this.Projects = projects;
        }
    }
}