﻿using CheckMyCode.Data.Models;
using CheckMyCode.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheckMyCode.Web.Areas.Projects.Models
{
    public class ProjectViewModel : IMapFrom<Project>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public IEnumerable<File> Files { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}