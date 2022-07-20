using Microsoft.EntityFrameworkCore;
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
    }

    /// <inheritdoc />
    public DbSet<Issue> Issues { get; protected set; }

    /// <inheritdoc />
    public new async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Issue>()
            .HasData(
                new Issue
                {
                    Id = 1,
                    Name = "Issue with inherited estimated hours",
                    Executors = "Executor",
                    Deadline = DateTime.UtcNow.AddDays(7),
                    Description = "Test description.",
                    CreatedAt = DateTime.UtcNow,
                    EstimatedHours = 100,
                    Status = Status.Assigned
                },
                new Issue
                {
                    Id = 2,
                    Name = "Second issue",
                    Executors = "Executor",
                    Deadline = DateTime.UtcNow.AddDays(7),
                    Description = "Test description.",
                    CreatedAt = DateTime.UtcNow,
                    EstimatedHours = 50,
                    Status = Status.InProgress,
                    IssueId = 1
                },
                new Issue
                {
                    Id = 3,
                    Name = "Third issue",
                    Executors = "Executor",
                    Deadline = DateTime.UtcNow.AddDays(7),
                    Description = "Test description.",
                    CreatedAt = DateTime.UtcNow,
                    EstimatedHours = 50,
                    Status = Status.Assigned,
                    IssueId = 1
                },
                new Issue
                {
                    Id = 4,
                    Name = "Issue with huge description",
                    Executors = "Executor",
                    Deadline = DateTime.UtcNow.AddDays(7),
                    Description = "Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string Very long string",
                    CreatedAt = DateTime.UtcNow,
                    EstimatedHours = 150,
                    Status = Status.Assigned
                },
                new Issue
                {
                    Id = 5,
                    Name = "Child issue",
                    Executors = "Executor",
                    Deadline = DateTime.UtcNow.AddDays(7),
                    CreatedAt = DateTime.UtcNow,
                    EstimatedHours = 150,
                    Status = Status.Assigned,
                    IssueId = 2
                },
                new Issue
                {
                    Id = 6,
                    Name = "Child child issue",
                    Executors = "Executor",
                    Deadline = DateTime.UtcNow.AddDays(7),
                    CreatedAt = DateTime.UtcNow,
                    EstimatedHours = 150,
                    Status = Status.Assigned,
                    IssueId = 5
                },
                new Issue
                {
                    Id = 7,
                    Name = "Child child child issue",
                    Executors = "Executor",
                    Deadline = DateTime.UtcNow.AddDays(7),
                    CreatedAt = DateTime.UtcNow,
                    EstimatedHours = 150,
                    Status = Status.Assigned,
                    IssueId = 6
                },
                new Issue
                {
                    Id = 8,
                    Name = "Child child child issue",
                    Executors = "Executor",
                    Deadline = DateTime.UtcNow.AddDays(7),
                    CreatedAt = DateTime.UtcNow,
                    EstimatedHours = 150,
                    Status = Status.Assigned,
                    IssueId = 7
                },
                new Issue
                {
                    Id = 9,
                    Name = "Child child child issue with many executors",
                    Executors = "Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor",
                    Deadline = DateTime.UtcNow.AddDays(7),
                    CreatedAt = DateTime.UtcNow,
                    EstimatedHours = 150,
                    Status = Status.Assigned,
                    IssueId = 8
                },
                new Issue
                {
                    Id = 10,
                    Name = "Issue with very very very very very very very very very very very very very very very very long name",
                    Executors = "Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor, Executor",
                    Deadline = DateTime.UtcNow.AddDays(7),
                    CreatedAt = DateTime.UtcNow,
                    EstimatedHours = 150,
                    Status = Status.Stopped
                }
            );
    }
}
