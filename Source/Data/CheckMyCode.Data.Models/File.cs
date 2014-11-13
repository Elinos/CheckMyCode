using CheckMyCode.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMyCode.Data.Models
{
    public class File : AuditInfo, IDeletableEntity
    {
        private readonly ICollection<Comment> comments;
        private readonly ICollection<FileRevision> fileRevisions;
        
        public File()
        {
            this.comments = new HashSet<Comment>();
            this.fileRevisions = new HashSet<FileRevision>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public byte[] Content { get; set; }

        [Required]
        public string Filename { get; set; }

        [Required]
        public LanguageType LanguageType { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Required]
        public Project Project { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }
        }

        public ICollection<FileRevision> FileRevisions
        {
            get
            {
                return this.fileRevisions;
            }
        }
    }
}