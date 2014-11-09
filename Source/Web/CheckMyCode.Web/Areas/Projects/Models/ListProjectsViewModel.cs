using AutoMapper;
using CheckMyCode.Data.Models;
using CheckMyCode.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckMyCode.Web.Areas.Projects.Models
{
    public class ListProjectsViewModel : IMapFrom<Project>, IHaveCustomMappings
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string OwnerUserName { get; set; }

        public LanguageType Language { get; set; }
        
        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Project, ListProjectsViewModel>()
                         .ForMember(m => m.OwnerUserName, options => options.MapFrom(p => p.Owner.UserName));

            configuration.CreateMap<Project, ListProjectsViewModel>()
                         .ForMember(m => m.Language,
                              options => options.MapFrom(p => p.Files
                                                               .GroupBy(f => f.LanguageType)
                                                               .OrderByDescending(c => c.Count())
                                                               .Take(1)
                                                               .FirstOrDefault()
                                                               .Key));
        }
    }
}