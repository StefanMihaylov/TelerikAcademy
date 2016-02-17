namespace ForumSystem.Web.Areas.Administration.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class CreatePostViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [UIHint("tinymce_full")]
        public string Content { get; set; }
    }
}