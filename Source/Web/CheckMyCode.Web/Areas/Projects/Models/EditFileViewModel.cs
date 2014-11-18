using CheckMyCode.Data.Models;
using CheckMyCode.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CheckMyCode.Web.Areas.Projects.Models
{
    public class EditFileViewModel : IMapFrom<File>, IHaveCustomMappings
    {
        [Required]
        public int FileId { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Required]
        [AllowHtml]
        public string FileAsString { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "The comment must be between 5 and 2000 chars!")]
        public string Comment { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<File, EditFileViewModel>()
                         .ForMember(f => f.FileId, options => options.MapFrom(f => f.Id));

            configuration.CreateMap<File, EditFileViewModel>()
                         .ForMember(f => f.FileAsString, options => options.MapFrom(f => Encoding.Default.GetString(f.Content)));
        }
    }
}