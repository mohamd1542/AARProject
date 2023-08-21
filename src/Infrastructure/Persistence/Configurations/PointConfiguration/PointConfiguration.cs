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
public class PointConfiguration : IEntityTypeConfiguration<Point>
{
    public void Configure(EntityTypeBuilder<Point> builder)
    {
        builder.ToTable("Point");

        builder.Property(e => e.PointName).HasMaxLength(100);

        builder.HasOne(d => d.User).WithMany(p => p.Points)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK_Points_Users");
    }
}
