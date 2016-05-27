using System;
using System.Data.Entity;
using SimpleBlog.Core.Models;

namespace SimpleBlog.Core.DAL
{
    public interface IBlogContext
    {
        DbSet<Post> Posts { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbSet Set(Type entityType);
    }
}