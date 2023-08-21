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
public class PointTemplateConfiguration : IEntityTypeConfiguration<PointTemplate>
{
    public void Configure(EntityTypeBuilder<PointTemplate> builder)
    {
        builder.ToTable("PointTemplate");

        builder.HasOne(d => d.Point).WithMany(p => p.PointTemplates)
            .HasForeignKey(d => d.PointId)
            .HasConstraintName("FK_PointTemplate_Points");

        builder.HasOne(d => d.Template).WithMany(p => p.PointTemplates)
            .HasForeignKey(d => d.TemplateId)
            .HasConstraintName("FK_PointTemplate_Template");
    }
}
