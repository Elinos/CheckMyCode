using AutoMapper;
using CheckMyCode.Data.Models;
using CheckMyCode.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckMyCode.Web.Areas.Projects.Models
{
    public class MyProjectsViewModel : IMapFrom<Project>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsPublic { get; set; }

        public LanguageType Language { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Project, MyProjectsViewModel>()
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