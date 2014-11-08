using CheckMyCode.Data.Models;
using CheckMyCode.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheckMyCode.Web.ViewModels.Projects
{
    public class ProjectViewModel : IMapFrom<Project>
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        public bool IsPublic { get; set; }

        [Required]
        public IEnumerable<File> Files { get; set; }
    }
}