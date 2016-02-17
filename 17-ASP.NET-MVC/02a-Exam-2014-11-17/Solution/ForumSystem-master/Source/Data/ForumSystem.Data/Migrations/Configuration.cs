namespace ForumSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using ForumSystem.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            // TODO: Remove in production
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AppDbContext context)
        {
            this.SeedUsers(context);
            this.SeedTags(context);
            this.SeedPosts(context);
        }

        private void SeedPosts(AppDbContext context)
        {
            if (context.Posts.Any())
            {
                return;
            }

            for (int i = 0; i < 15; i++)
            {
                var tags = this.GetTags(context, 3, 4);
                var postContent = RandomGenerator.Instance.GetString(50, 100);

                var post = new Post()
                {
                    Title = RandomGenerator.Instance.GetString(10, 20),
                    AuthorId = this.GetAuthorId(context),
                    Content = postContent,
                    Tags = tags
                };

                context.Posts.Add(post);
            }

            context.SaveChanges();
        }

        private string GetAuthorId(AppDbContext context)
        {
            var allAutothorIds = context.Users.Select(u => u.Id).ToList();
            var index = RandomGenerator.Instance.GetNumber(0, allAutothorIds.Count - 1);

            return allAutothorIds[index];
        }

        private ICollection<Tag> GetTags(AppDbContext context, int minCount, int maxCount)
        {
            var tagsIds = new HashSet<int>();
            var count = RandomGenerator.Instance.GetNumber(minCount, maxCount);

            var allTagIds = context.Tags.Select(t => t.Id).ToList();
            var totalTags = allTagIds.Count;

            while (tagsIds.Count < count)
            {
                var randomIdIndex = RandomGenerator.Instance.GetNumber(0, totalTags - 1);
                tagsIds.Add(allTagIds[randomIdIndex]);
            }

            var tags = new List<Tag>();
            foreach (var tagId in tagsIds)
            {
                var currentTag = context.Tags.Find(tagId);
                tags.Add(currentTag);
            }

            return tags;
        }

        private void SeedTags(AppDbContext context)
        {
            if (context.Tags.Any())
            {
                return;
            }

            for (int i = 0; i < 20; i++)
            {
                var name = RandomGenerator.Instance.GetString(5, 10);
                var tag = new Tag()
                {
                    Name = name
                };

                context.Tags.AddOrUpdate(tag);
            }

            context.SaveChanges();
        }

        private void SeedUsers(AppDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var userManager = new UserManager<User>(new UserStore<User>(context));

            for (int i = 0; i < 10; i++)
            {
                var emailDomain = RandomGenerator.Instance.GetString(6, 16);
                var emailUsername = RandomGenerator.Instance.GetString(6, 16);
                var email = string.Format("{0}@{1}.com", emailUsername, emailDomain);
                var user = new User
                {
                    Email = email,
                    UserName = email
                };

                userManager.Create(user, "aaaaaa");
            }

            context.SaveChanges();
        }
    }
}
