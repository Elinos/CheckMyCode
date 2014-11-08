using CheckMyCode.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMyCode.Data.Models
{
    public class Project : AuditInfo, IDeletableEntity
    {
        public Project()
        {
            this.Files = new HashSet<File>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string OwnerId { get; set; }

        public ApplicationUser Owner { get; set; }

        [Index]
        public bool IsPublic { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
        
        public virtual ICollection<File> Files { get; set; }
    }
}