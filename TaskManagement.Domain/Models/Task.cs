namespace TaskManagement.Domain.Models;

/// <summary>
/// Task.
/// </summary>
public class Task
{
    /// <summary>
    /// Identifier.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Name.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Description.
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// The people who responsible for the task.
    /// </summary>
    public string Executors { get; init; }

    /// <summary>
    /// Status.
    /// </summary>
    public string Status { get; init; }

    /// <summary>
    /// Estimated time to complete the task.
    /// </summary>
    public int EstimatedHours { get; init; }

    /// <summary>
    /// The date when the task was created.
    /// </summary>
    public DateTime CreatedAt { get; init; }

    /// <summary>
    /// The time when the task was completed.
    /// </summary>
    public DateTime CompletedAt { get; init; }

    /// <summary>
    /// The date when the task should have already been completed.
    /// </summary>
    public DateTime Deadline { get; init; }
}
