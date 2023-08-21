using AARProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AARProject.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Source> Sources { get; }
    DbSet<User> Users { get; }
    DbSet<Role> Roles { get; }
    DbSet<UserRole> UserRoles { get; }
    DbSet<Template> Templates { get; }
    DbSet<Point> Points { get; }
    DbSet<PointTemplate> PointTemplates { get; }
    DbSet<RoleTemplate> RoleTemplates { get; }
    DbSet<RoleSource> RoleSources { get; }
    DbSet<Comment> Comments { get; }
    DbSet<UploadedFile> Files { get; }
    DbSet<UserRequestTemplate> UserRequestTemplates { get; }
    DbSet<UserRpointTemplate> UserRpointTemplates { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
