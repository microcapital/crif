using CRIF.CodeTest2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRIF.CodeTest2.API.Contexts
{
    public class NovelDatabaseContext : DbContext
    {
        public NovelDatabaseContext(
            DbContextOptions<NovelDatabaseContext> dbContextOptions)
            : base(dbContextOptions) { }

        public DbSet<Novel> Novels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Novel>()
                .HasKey(x => x.Id);
        }
    }
}
