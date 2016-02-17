namespace ForumSystem.Web.Areas.Administration.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;

    public class AdminPostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string Author { get; set; }

        [Required]

        // [AllowHtml]
        [Display(Name = "Content")]

        // [DataType("tinymce_full")]
        // [UIHint("tinymce_full")]
        [UIHint("ContentTextArea")]
        public string Content { get; set; }

        [DisplayName("Created on")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}")]
        public DateTime? CreatedOn { get; set; }

        [DisplayName("Modified on")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}")]
        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Post, AdminPostViewModel>()
                .ForMember(m => m.Author, opt => opt.MapFrom(u => u.Author.UserName));
        }
    }
}