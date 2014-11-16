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
        private ICollection<FileRevision> fileRevisions;
        
        public File()
        {
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
        public virtual Project Project { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
        
        public virtual ICollection<FileRevision> FileRevisions
        {
            get
            {
                return this.fileRevisions;
            }
            set
            {
                this.fileRevisions = value;
            }
        }
    }
}