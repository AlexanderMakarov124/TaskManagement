using System.ComponentModel.DataAnnotations;
using TaskManagement.Domain.Models;

namespace TaskManagement.Domain.Dtos;
public record IssueDto
{
    /// <inheritdoc cref="Issue.Id"/>
    public int Id { get; init; }

    /// <inheritdoc cref="Issue.Name"/>
    public string? Name { get; init; }

    /// <inheritdoc cref="Issue.Description"/>
    public string? Description { get; init; }

    /// <inheritdoc cref="Issue.Executors"/>
    public string Executors { get; init; }

    /// <inheritdoc cref="Issue.Status"/>
    public string Status { get; init; }

    /// <inheritdoc cref="Issue.EstimatedHours"/>
    public int EstimatedHours { get; init; }

    /// <inheritdoc cref="Issue.Deadline"/>
    public DateTime Deadline { get; init; }

    /// <inheritdoc cref="Issue.IssueId"/>
    public int? IssueId { get; init; }

    /// <inheritdoc cref="Issue.CreatedAt"/>
    public DateTime CreatedAt { get; init; }

    /// <inheritdoc cref="Issue.CompletedAt"/>
    public DateTime? CompletedAt { get; init; }

    /// <summary>
    /// Describes sub issues existence.
    /// </summary>
    public bool HasSubIssues { get; init; }
}
