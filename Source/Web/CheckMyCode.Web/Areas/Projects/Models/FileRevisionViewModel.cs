using AutoMapper;
using CheckMyCode.Data.Models;
using CheckMyCode.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckMyCode.Web.Areas.Projects.Models
{
    public class FileRevisionViewModel : IMapFrom<FileRevision>, IHaveCustomMappings
    {
        public int Id { get; set; }
        
        public byte[] ChangedFile { get; set; }

        public string Comment { get; set; }

        public int FileId { get; set; }

        public string AuthorName { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<FileRevision, FileRevisionViewModel>()
                         .ForMember(m => m.AuthorName, options => options.MapFrom(p => p.Author.UserName));
        }
    }
}