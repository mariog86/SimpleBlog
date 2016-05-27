using System.Data.Entity.ModelConfiguration;
using SimpleBlog.Core.Models;

namespace SimpleBlog.Core.Mappings
{
    public class TagMapping : EntityTypeConfiguration<Tag>
    {
        public TagMapping()
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
                .WithMany(t => t.Tags)
                .Map(m => m.ToTable("PostTagMap"));
        }
    }
}