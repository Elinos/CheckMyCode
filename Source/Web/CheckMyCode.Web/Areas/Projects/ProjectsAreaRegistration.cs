using System.Web.Mvc;

namespace CheckMyCode.Web.Areas.Projects
{
    public class ProjectsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Projects";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Project_info",
                "Projects/Project/{id}",
                new { controller = "Project", action = "Index" });
            context.MapRoute(
                "Projects_default",
                "Projects/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });
        }
    }
}