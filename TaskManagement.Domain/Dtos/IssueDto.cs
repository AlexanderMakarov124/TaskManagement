using TaskManagement.Domain.Models;

namespace TaskManagement.Domain.Dtos;
public class IssueDto
{
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
}
