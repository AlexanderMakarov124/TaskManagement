using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TaskManagement.Abstractions.DataAccess;
using TaskManagement.Domain.Models;

namespace TaskManagement.DataAccess;

/// <summary>
/// Application context.
/// </summary>
public class ApplicationContext : DbContext, IApplicationContext
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    /// <inheritdoc />
    public DbSet<Issue> Issues { get; protected set; }

    /// <inheritdoc />
    public new async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await base.SaveChangesAsync(cancellationToken);
    }

    public override EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
    {
        return base.Entry(entity);
    }
}
