using CheckMyCode.Data.Models;
using CheckMyCode.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckMyCode.Web.Areas.Projects.Models
{
    public class AddCommentViewModel : IMapFrom<Comment>
    {
        public AddCommentViewModel()
        {
        }

        public AddCommentViewModel(int projectId)
        {
            this.ProjectId = projectId; 
        }

        [Required]
        public int ProjectId { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Required!")]
        [StringLength(2000, MinimumLength = 5, ErrorMessage = "The comment must be between 5 and 2000 chars!")]
        public string Text { get; set; }
    }
}