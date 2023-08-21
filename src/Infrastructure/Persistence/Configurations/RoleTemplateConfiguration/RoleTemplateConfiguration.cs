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
public class RoleTemplateConfiguration : IEntityTypeConfiguration<RoleTemplate>
{
    public void Configure(EntityTypeBuilder<RoleTemplate> builder)
    {
        builder.ToTable("RoleTemplate");

        builder.HasOne(d => d.Role).WithMany(p => p.RoleTemplates)
            .HasForeignKey(d => d.RoleId)
            .HasConstraintName("FK_RoleTemplate_Roles");

        builder.HasOne(d => d.Template).WithMany(p => p.RoleTemplates)
            .HasForeignKey(d => d.TemplateId)
            .HasConstraintName("FK_RoleTemplate_Template");
    }
}
