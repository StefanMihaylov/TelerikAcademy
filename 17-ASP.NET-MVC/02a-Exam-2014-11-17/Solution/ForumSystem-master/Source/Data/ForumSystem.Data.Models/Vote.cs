namespace ForumSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using ForumSystem.Data.Common.Models;

    public class Vote : AuditInfo, IDeletableEntity
    {
        [Key]
        public int VoteId { get; set; }

        public int Value { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
