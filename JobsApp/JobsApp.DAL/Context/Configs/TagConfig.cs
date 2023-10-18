using JobsApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobsApp.DAL.Context.Configs
{
    public class TagConfig : IEntityTypeConfiguration<TagEntity>
    {
        public void Configure(EntityTypeBuilder<TagEntity> builder)
        {
            builder.ToTable("ja_tags");
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Title).IsUnique();

            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Title)
                .HasColumnName("title")
                .HasMaxLength(50)
                .IsRequired(true);
        }
    }
}