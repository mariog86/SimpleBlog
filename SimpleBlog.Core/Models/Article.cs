using System;

namespace SimpleBlog.Core.Models
{
    public class Article
    {
        public int Id { get; set; }

        public string Category { get; set; }

        public string Title { get; set; }

        public string RelativeFilePath { get; set; }

        public DateTime Created { get; set; }
    }
}