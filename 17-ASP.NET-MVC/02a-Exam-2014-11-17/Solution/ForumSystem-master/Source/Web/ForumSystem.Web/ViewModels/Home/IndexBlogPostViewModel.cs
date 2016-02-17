namespace ForumSystem.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;

    public class IndexBlogPostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public ICollection<string> Tags { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Post, IndexBlogPostViewModel>()
                .ForMember(m => m.Tags, opt => opt.MapFrom(u => u.Tags.Select(t => t.Name)));
        }
    }
}