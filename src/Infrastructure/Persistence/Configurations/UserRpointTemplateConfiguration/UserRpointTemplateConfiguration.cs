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
public class UserRpointTemplateConfiguration : IEntityTypeConfiguration<UserRpointTemplate>
{
    public void Configure(EntityTypeBuilder<UserRpointTemplate> builder)
    {
        builder.ToTable("UserRPointTemplates");

        builder.Property(e => e.Created).HasColumnType("date");
        builder.Property(e => e.Text).HasMaxLength(50);

        builder.HasOne(d => d.PointTemplate).WithMany(p => p.UserRpointTemplates)
            .HasForeignKey(d => d.PointTemplateId)
            .HasConstraintName("FK_UserRPointTemplates_PointTemplate");

        builder.HasOne(d => d.UserRequestTemplate).WithMany(p => p.UserRpointTemplates)
            .HasForeignKey(d => d.UserRequestTemplateId)
            .HasConstraintName("FK_UserRPointTemplates_UserRequestTemplate");
    }
}
