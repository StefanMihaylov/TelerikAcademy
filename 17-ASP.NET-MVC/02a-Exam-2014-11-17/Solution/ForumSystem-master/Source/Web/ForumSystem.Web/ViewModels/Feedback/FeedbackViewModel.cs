namespace ForumSystem.Web.ViewModels.Feedback
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;

    public class FeedbackViewModel : IMapFrom<Feedback>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        // [UIHint("SanitisedText")]
        // [AllowSanitizedHtml]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Feedback, FeedbackViewModel>()
                .ForMember(m => m.Author, opt => opt.MapFrom(u => u.Author.UserName));
        }
    }
}