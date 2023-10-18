using JobsApp.DAL.Context.Configs;
using JobsApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobsApp.DAL.Context
{
    public sealed class AppPgContext : DbContext
    {
        public AppPgContext(DbContextOptions<AppPgContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<JobEntity> Jobs { get; set; }
        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<TagEntity> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new JobConfig().Configure(modelBuilder.Entity<JobEntity>());
            new CompanyConfig().Configure(modelBuilder.Entity<CompanyEntity>());
            new TagConfig().Configure(modelBuilder.Entity<TagEntity>());

            modelBuilder.Entity<JobEntity>()
                .HasMany(j => j.Tags)
                .WithMany(t => t.Jobs)
                .UsingEntity<JobTagEntity>();
        }
    }
}