using System;
using System.Collections.Generic;
using SimpleBlog.Core.Models;

namespace SimpleBlog.Core.DAL
{
    public class BlogInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            var articles = new List<Article>
            {
                new Article
                {
                    Id = 3,
                    Title = "My Visual Studio's Greatest Hits",
                    Category = "Visual Studio",
                    RelativeFilePath = "VisStudio1.htm",
                    Created = new DateTime(2015, 4, 2)
                },
                new Article
                {
                    Id = 2,
                    Title = "My Develop For Android",
                    Category = "|Android Dev",
                    RelativeFilePath = "AndroidDev1.htm",
                    Created = new DateTime(2015, 4, 2)
                },
                new Article
                {
                    Id = 1,
                    Title = "My Biggest Tech Article Ever",
                    Category = "Tech",
                    RelativeFilePath = "TechBlog1.htm",
                    Created = new DateTime(2015, 3, 1)
                }
            };

            articles.ForEach(s => context.Articles.Add(s));
            context.SaveChanges();
        }
    }
}