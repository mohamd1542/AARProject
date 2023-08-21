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
public class RoleSourceConfiguration : IEntityTypeConfiguration<RoleSource>
{
    public void Configure(EntityTypeBuilder<RoleSource> builder)
    {
        builder.ToTable("RoleSource");

        builder.HasOne(d => d.Role).WithMany(p => p.RoleSources)
            .HasForeignKey(d => d.RoleId)
            .HasConstraintName("FK_RoleSource_Roles");

        builder.HasOne(d => d.Source).WithMany(p => p.RoleSources)
            .HasForeignKey(d => d.SourceId)
            .HasConstraintName("FK_RoleSource_Source");
    }
}
