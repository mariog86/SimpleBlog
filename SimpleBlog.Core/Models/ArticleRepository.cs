using System;
using System.Collections.Generic;
using System.IO;

namespace SimpleBlog.Core.Models
{
    public class ArticleRepository : List<Article>
    {
        private readonly string _rootPath;
        private readonly string _blogFile;

        public ArticleRepository(string rootPath, string blogFile)
        {
            _rootPath = rootPath;
            _blogFile = blogFile;
            GetAllBlogArticles(false);
        }

        public void GetAllBlogArticles(bool? forceReload)
        {
            if (Count == 0 || (forceReload == true))
            {
                Clear();
                LoadBlogArticlesFromDataStore();
            }
        }

        private void LoadBlogArticlesFromDataStore()
        {
            string[] allLines = File.ReadAllLines(Path.Combine(_rootPath, _blogFile));
            foreach (string line in allLines)
            {
                try
                {
                    string[] allItems = line.Split('|');

                    Article ba = new Article
                    {
                        Id = Convert.ToInt32(allItems[0]),
                        Title = allItems[1],
                        Category = allItems[2],
                        RelativeFilePath = allItems[3],
                        Created = DateTime.Parse(allItems[4])
                    };
                    //id 1; newest first (top of file)
                    // "Biggest Tech Article Ever";
                    //"Tech";
                    // "TechBlog1.htm";
                    // 2015-03-31
                    Add(ba);
                }
                finally
                {
                    // if any fail, just move to the next one
                    // do not stop the app for any reason!
                }
            }
        }

    }
}