using CheckMyCode.Data.Models;
using CheckMyCode.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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

        [Required]
        [StringLength(2000, MinimumLength = 50)]
        public string Text { get; set; }
    }
}