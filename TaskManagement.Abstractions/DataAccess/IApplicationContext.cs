using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Models;

namespace TaskManagement.Abstractions.DataAccess;

/// <summary>
/// Application context interface.
/// </summary>
public interface IApplicationContext
{
    /// <summary>
    /// Issues.
    /// </summary>
    DbSet<Issue> Issues { get; }

    /// <summary>
    /// Saves pending changes.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
