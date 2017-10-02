using devOpsProject2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devOpsProject2.Context
{
    public class MySqlContext : DbContext
    {//https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/new-db
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<CD> CD { get; set; }
        public DbSet<Track> Track { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CD>().HasKey(m => m.Id);
            builder.Entity<Track>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }

    }
}
