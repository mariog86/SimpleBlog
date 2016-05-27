using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SimpleBlog.Core.Models;

namespace SimpleBlog.Core.DAL
{
    public class BlogContext : DbContext, IBlogContext
    {

        public BlogContext() : base("BlogContext")
        {
        }

        public BlogContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}