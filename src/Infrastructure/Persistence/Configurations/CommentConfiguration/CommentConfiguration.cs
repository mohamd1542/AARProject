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
public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comment");
        builder.Property(e => e.CommentDate).HasColumnType("date");
        builder.Property(e => e.Text).HasMaxLength(50);
        builder.Property(e => e.UserRpointTemplateId).HasColumnName("UserRPointTemplateId");

        builder.HasOne(d => d.CommentNavigation).WithMany(p => p.InverseCommentNavigation)
            .HasForeignKey(d => d.CommentId)
            .HasConstraintName("FK_Comments_Comments");

        builder.HasOne(d => d.User).WithMany(p => p.Comments)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK_Comments_Users");

        builder.HasOne(d => d.UserRpointTemplate).WithMany(p => p.Comments)
            .HasForeignKey(d => d.UserRpointTemplateId)
            .HasConstraintName("FK_Comments_UserRPointTemplates");
    }
}

