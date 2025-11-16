using AARProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AARProject.Infrastructure.Persistence.Configurations
{
    public class UserRequestTemplateConfiguration : IEntityTypeConfiguration<UserRequestTemplate>
    {
        public void Configure(EntityTypeBuilder<UserRequestTemplate> builder)
        {
            builder.ToTable("UserRequestTemplate");

            builder.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");

            builder.Property(e => e.File)
                .HasMaxLength(50)
                .HasColumnName("file");

            // Point
            builder.HasOne(d => d.Point)
                .WithMany(p => p.UserRequestTemplates)
                .HasForeignKey(d => d.PointId)
                .HasConstraintName("FK_UserRequestTemplate_Points");

            // Source
            builder.HasOne(d => d.Source)
                .WithMany(p => p.UserRequestTemplates)
                .HasForeignKey(d => d.SourceId)
                .HasConstraintName("FK_UserRequestTemplate_Source");

            // Template
            builder.HasOne(d => d.Template)
                .WithMany(p => p.UserRequestTemplates)
                .HasForeignKey(d => d.TemplateId)
                .HasConstraintName("FK_UserRequestTemplate_Template");

            // User – هنا وقفنا الـ Cascade Delete
            builder.HasOne(d => d.User)
                .WithMany(p => p.UserRequestTemplates)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.NoAction)   // أو DeleteBehavior.Restrict
                .HasConstraintName("FK_UserRequestTemplate_Users");
        }
    }
}
