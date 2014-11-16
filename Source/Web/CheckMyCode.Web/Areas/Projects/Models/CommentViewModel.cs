using AutoMapper;
using CheckMyCode.Data.Models;
using CheckMyCode.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckMyCode.Web.Areas.Projects.Models
{
    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string AuthorName { get; set; }

        public int ProjectId { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                         .ForMember(m => m.AuthorName, opt => opt.MapFrom(c => c.Author.UserName))
                         .ReverseMap();
        }
    }
}