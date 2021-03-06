﻿using CheckMyCode.Data.Models;
using CheckMyCode.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheckMyCode.Web.Areas.Projects.Models
{
    public class CreateProjectViewModel : IMapFrom<Project>
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        public bool IsPublic { get; set; }

        [Required]
        public HttpPostedFileBase File { get; set; }
    }
}