using JobsApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobsApp.DAL.Context.Configs
{
    public class CompanyConfig : IEntityTypeConfiguration<CompanyEntity>
    {
        public void Configure(EntityTypeBuilder<CompanyEntity> builder)
        {
            builder.ToTable("ja_companies");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Title)
                .HasColumnName("title")
                .HasMaxLength(255)
                .IsRequired(true);

            builder.Property(x => x.Location)
                .HasColumnName("location")
                .HasMaxLength(255);

            builder.Property(x => x.Logo)
                .HasColumnName("logo_src")
                .HasMaxLength(255);

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp(0)");
        }
    }
}