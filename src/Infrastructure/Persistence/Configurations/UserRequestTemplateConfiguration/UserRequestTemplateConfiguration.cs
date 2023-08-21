using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARProject.Domain.Entities;
using IdentityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AARProject.Infrastructure.Persistence.Configurations;
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

        builder.HasOne(d => d.Point).WithMany(p => p.UserRequestTemplates)
            .HasForeignKey(d => d.PointId)
            .HasConstraintName("FK_UserRequestTemplate_Points");

        builder.HasOne(d => d.Source).WithMany(p => p.UserRequestTemplates)
            .HasForeignKey(d => d.SourceId)
            .HasConstraintName("FK_UserRequestTemplate_Source");

        builder.HasOne(d => d.Template).WithMany(p => p.UserRequestTemplates)
            .HasForeignKey(d => d.TemplateId)
            .HasConstraintName("FK_UserRequestTemplate_Template");

        builder.HasOne(d => d.User).WithMany(p => p.UserRequestTemplates)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK_UserRequestTemplate_Users");
    }
}
