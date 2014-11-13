using CheckMyCode.Data.Models;
using CheckMyCode.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CheckMyCode.Web.Areas.Projects.Models
{
    public class FilesViewModel : IMapFrom<File>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Filename { get; set; }

        public string LanguageType { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<File, FilesViewModel>()
                         .ForMember(f => f.LanguageType, options => options.MapFrom(f => f.LanguageType.ToString().ToLower()));

            configuration.CreateMap<File, FilesViewModel>()
                         .ForMember(f => f.Content, options => options.MapFrom(f => Encoding.Default.GetString(f.Content)));
        }
    }
}