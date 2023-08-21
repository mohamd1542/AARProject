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
public class UploadedFileConfiguration : IEntityTypeConfiguration<UploadedFile>
{
    public void Configure(EntityTypeBuilder<UploadedFile> builder)
    {
        builder.ToTable("UploadedFile");
        builder.Property(e => e.FileName).HasMaxLength(75);

        builder.HasOne(d => d.UserRequestTemplate).WithMany(p => p.UploadedFiles)
            .HasForeignKey(d => d.UserRequestTemplateId)
            .HasConstraintName("FK_UploadedFiles_UserRequestTemplate");
    }
}
