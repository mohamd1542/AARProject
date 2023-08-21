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
public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRole");

        builder.HasOne(d => d.Role).WithMany(p => p.UserRoles)
            .HasForeignKey(d => d.RoleId)
            .HasConstraintName("FK_UserRole_Roles");

        builder.HasOne(d => d.User).WithMany(p => p.UserRoles)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK_UserRole_Users");
    }
}
