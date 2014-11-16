using CheckMyCode.Data.Models;
using CheckMyCode.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheckMyCode.Web.Areas.Administration.Models
{
    public class ProjectsAdministrationViewModel : IMapFrom<Project>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string OwnerUsername { get; set; }

        public bool IsPublic { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Project, ProjectsAdministrationViewModel>()
                         .ForMember(m => m.OwnerUsername, opt => opt.MapFrom(c => c.Owner.UserName));
        }
    }
}