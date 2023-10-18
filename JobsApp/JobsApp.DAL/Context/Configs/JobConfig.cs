using JobsApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobsApp.DAL.Context.Configs
{
    public class JobConfig : IEntityTypeConfiguration<JobEntity>
    {
        public void Configure(EntityTypeBuilder<JobEntity> builder)
        {
            builder.ToTable("ja_jobs");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Title)
                .HasColumnName("title")
                .HasMaxLength(255)
                .IsRequired(true);

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasColumnType("text");

            builder.Property(x => x.Salary)
                .HasColumnName("salary")
                .HasColumnType("numeric(8,2)");

            builder.Property(x => x.Location)
                .HasColumnName("location")
                .HasMaxLength(255);

            builder.Property(x => x.SalaryType)
                .HasColumnName("salary_type");

            builder.Property(x => x.TimeType)
                .HasColumnName("time_type");

            builder.Property(x => x.EmploymentType)
                .HasColumnName("employment_type");

            builder.Property(x => x.IsClosed)
                .HasColumnName("is_closed")
                .HasDefaultValue(false);

            builder.Property(x => x.IsDeleted)
                .HasColumnName("is_deleted")
                .HasDefaultValue(false);

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp(0)");

            builder.Property(x => x.UpdateAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp(0)");

            builder.Property(x => x.CompanyId)
                .HasColumnName("company_name");

            builder.HasOne(x => x.Company)
                .WithMany(c => c.PublicatedJobs)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}