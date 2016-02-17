namespace ForumSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ForumSystem.Data.Common.Models;

    public class Feedback : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 10)]
        public string Content { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
