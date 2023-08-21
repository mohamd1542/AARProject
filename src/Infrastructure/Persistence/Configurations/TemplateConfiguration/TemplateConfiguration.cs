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
public class TemplateConfiguration : IEntityTypeConfiguration<Template>
{
    public void Configure(EntityTypeBuilder<Template> builder)
    {
        builder.ToTable("Template");

        builder.Property(e => e.CoverImage).HasColumnType("image");
        builder.Property(e => e.Description).HasMaxLength(100).HasColumnName("description");
        builder.Property(e => e.TemplateName).HasMaxLength(100);
    }
}
