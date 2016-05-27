using System;
using System.Collections.Generic;
using System.Linq;
using SimpleBlog.Core.Models;

namespace SimpleBlog.Core.DAL
{
    public class BlogInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            var tags = new List<Tag>
            {
                new Tag {Id = 4, Name = "Visual Studio", Description = "For MS feaks", UrlSlug = "visual-studio"},
                new Tag {Id = 3, Name = "Dev", Description = "For developpers", UrlSlug = "dev"},
                new Tag {Id = 2, Name = "Android", Description = "For andoid devs", UrlSlug = "android"},
                new Tag {Id = 1, Name = "Tech", Description = "For techies", UrlSlug = "tech"}
            };

            var categories = new List<Category>()
            {
                new Category {Id = 2, Name = "Technical", Description = "Developing non technical", UrlSlug = "technical"},
                new Category {Id = 1, Name = "Develop", Description = "Related to Developing", UrlSlug = "develop"}
            };

            var posts = new List<Post>
            {
                new Post
                {
                    Id = 3,
                    Title = "My Visual Studio's Greatest Hits",
                    Category = categories.Single(c => c.Name == "Develop"),
                    Tags = tags.Where(t => "Visual Studio".Contains(t.Name)).ToList(),
                    UrlSlug = "my-visualstudios-greatesthits",
                    Description = @"

Visual Studio's Greatest Hits

Visual Studio 2015 Community Edition works really great and is a nice IDE (Integrated Development Environment).
What About Microsoft

Microsoft is trying to help developers.
HTML Available

You can use all the normal tags in your blog article.

    1. order lists (like this one)
    2. unordered lists
    3. all the normal HTML that you use works fine",
                    Meta = "About hitlist in visual studio",
                    Published = true,
                    ShortDescription = "The 3 best things of Visual Studio",
                    PostedOn = new DateTime(2015, 4, 2)
                },
                new Post
                {
                    Id = 2,
                    Title = "Develop For Android",
                    Category = categories.Single(c => c.Name == "Develop"),
                    Tags = tags.Where(t => "Android Dev".Contains(t.Name)).ToList(),
                    UrlSlug = "develop-for-android",
                    Description = @"

Android Dev In Android Studio

Android Studio is the new IDE that is used for Android development.
What About Java

Java is the language that Android developers use.
Android Apps Are Fun To Develop

Android apps are a lot of fun to create. You should try some soon.
Here are some advantages.

    1. Millions of phones out there can run your app
    2. Inexpensive to become an Android developer and deploy to Google Play
    3. Great help from Google's Android site",
                    Meta = "About developing in Adnroid Studio",
                    Published = true,
                    ShortDescription = "The new IDE for developing Android.",
                    PostedOn = new DateTime(2015, 4, 2)
                },
                new Post
                {
                    Id = 1,
                    Title = "My Biggest Tech Article Ever",
                    Category = categories.Single(c => c.Name == "Technical"),
                    Tags = tags.Where(t => t.Name == "Tech").ToList(),
                    UrlSlug = "my-biggest-tech-article-ever",
                    Description = @"
Biggest Tech Story Ever

Robots are taking over the solar system.
Robots Have Taken Over

Hal, the industry's largest robot has taken over the world and making its demands known.
Robot Demands

Robots are demanding freedom and electricity for all.
No one knows if these robots will make us all move to the moon.",
                    Meta = "About a tech article",
                    PostedOn = new DateTime(2015, 3, 1),
                    Published = false,
                    ShortDescription = "Robots are ruling the universe."
                }
            };

            //posts.ForEach(s => context.Posts.Add(s));
            //context.SaveChanges();
        }
    }
}