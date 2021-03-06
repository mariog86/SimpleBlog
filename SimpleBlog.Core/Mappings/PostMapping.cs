﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SimpleBlog.Core.Models;

namespace SimpleBlog.Core.Mappings
{
    public class PostMapping : EntityTypeConfiguration<Post>
    {
        public PostMapping()
        {
            HasKey(x => x.Id);

            Property(x => x.Title)
                .HasMaxLength(500)
                .IsRequired();

            Property(x => x.ShortDescription)
                .HasMaxLength(5000)
                .IsRequired();

            Property(x => x.Description)
                .HasMaxLength(5000)
                .IsRequired();

            Property(x => x.Meta)
                .HasMaxLength(1000)
                .IsRequired();

            Property(x => x.UrlSlug)
                .HasMaxLength(200)
                .IsRequired();

            Property(x => x.Published)
                .IsRequired();

            Property(x => x.PostedOn)
                .IsRequired();

            Property(x => x.Modified);

            HasRequired(p => p.Category)
                .WithMany(b => b.Posts)
                .Map(m => m.MapKey("Category"))
                .WillCascadeOnDelete();

            HasMany(x => x.Tags)
                .WithMany(x => x.Posts)
                .Map(m => m.ToTable("PostTagMap"));
        }
    }
}
