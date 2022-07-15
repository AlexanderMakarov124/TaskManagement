using MediatR;
using TaskManagement.Domain.Models;

namespace TaskManagement.UseCases.Issues.CreateIssue;

/// <summary>
/// Create issue command.
/// </summary>
public record CreateIssueCommand : IRequest
{
    /// <summary>
    /// Name.
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// Description.
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// The people who responsible for the issue.
    /// </summary>
    public string Executors { get; init; }

    /// <summary>
    /// Status.
    /// </summary>
    public string Status { get; init; }

    /// <summary>
    /// Estimated time to complete the issue.
    /// </summary>
    public int EstimatedHours { get; init; }

    /// <summary>
    /// The date when the issue should have already been completed.
    /// </summary>
    public DateTime Deadline { get; init; }
}