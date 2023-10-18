using JobsApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobsApp.DAL.Context.Configs
{
    public class JobTagConfig : IEntityTypeConfiguration<JobTagEntity>
    {
        public void Configure(EntityTypeBuilder<JobTagEntity> builder)
        {
            builder.ToTable("ja_job_tags");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.JobId).HasColumnName("job_id");
            builder.Property(x => x.TagId).HasColumnName("tag_id");
        }
    }
}