using System.Data.Entity.ModelConfiguration;
using SimpleBlog.Core.Models;

namespace SimpleBlog.Core.Mappings
{
    public class CategoryMapping : EntityTypeConfiguration<Category>
    {
        public CategoryMapping()
        {
            HasKey(x => x.Id);

            Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.UrlSlug)
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.Description)
                .HasMaxLength(200);
            
            HasMany(x => x.Posts)
                .WithRequired(t => t.Category)
                .HasForeignKey(d => d.Category)
                .WillCascadeOnDelete(true);
        }
    }
}