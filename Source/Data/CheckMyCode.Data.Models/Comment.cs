using CheckMyCode.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMyCode.Data.Models
{
    public class Comment : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(2000, MinimumLength = 50)]
        public string Text { get; set; }
        
        public string AuthorId { get; set; }
        
        public virtual ApplicationUser Author { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}