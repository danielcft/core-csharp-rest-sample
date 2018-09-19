﻿using Microsoft.EntityFrameworkCore;
using TodoREST.Models;

namespace TodoREST.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions options)
      : base(options)
    {
    }

    public virtual DbSet<Todo> Todo { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Todo>(entity =>
      {
        entity.Property(e => e.Message)
          .IsRequired()
          .HasMaxLength(255)
          .IsUnicode(false);
      });
    }
  }
}