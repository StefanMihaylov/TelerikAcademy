namespace ForumSystem.Web.ViewModels.Home
{
    using System.Linq;
    using AutoMapper;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;

    public class VotesViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int PostId { get; set; }

        public string UserId { get; set; }

        public int Votes { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Post, VotesViewModel>()
                .ForMember(m => m.Votes, opt => opt.MapFrom(u => u.Votes.Where(v => !v.IsDeleted).Sum(v => v.Value)));
        }
    }
}