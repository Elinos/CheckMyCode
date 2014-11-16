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
        private ICollection<File> files;
        private ICollection<Comment> comments;

        public Project()
        {
            this.files = new HashSet<File>();
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        [Index]
        public bool IsPublic { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
        
        public virtual ICollection<File> Files
        {
            get
            {
                return this.files;
            }
            set
            {
                this.files = value;
            }
        }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }
    }
}