using System.Reflection;
using AARProject.Application.Common.Interfaces;
using AARProject.Domain.Entities;
using AARProject.Infrastructure.Identity;
using AARProject.Infrastructure.Persistence.Interceptors;
using Duende.IdentityServer.EntityFramework.Options;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AARProject.Infrastructure.Persistence;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
{
    private readonly IMediator _mediator;
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public DbSet<Source> Sources => Set<Source>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<Template> Templates => Set<Template>();
    public DbSet<Point> Points => Set<Point>();
    public DbSet<PointTemplate> PointTemplates => Set<PointTemplate>();
    public DbSet<RoleTemplate> RoleTemplates => Set<RoleTemplate>();
    public DbSet<RoleSource> RoleSources => Set<RoleSource>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<UploadedFile> Files => Set<UploadedFile>();
    public DbSet<UserRequestTemplate> UserRequestTemplates => Set<UserRequestTemplate>();
    public DbSet<UserRpointTemplate> UserRpointTemplates => Set<UserRpointTemplate>();

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions,
        IMediator mediator,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) 
        : base(options, operationalStoreOptions)
    {
        _mediator = mediator;
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }
}
