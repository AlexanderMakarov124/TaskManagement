﻿using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain.Models;

/// <summary>
/// Issue.
/// </summary>
public class Issue
{
    /// <summary>
    /// Identifier.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Name.
    /// </summary>
    [Required]
    [StringLength(100)]
    public string Name { get; init; }

    /// <summary>
    /// Description.
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// The people who responsible for the issue.
    /// </summary>
    [Required]
    public string Executors { get; init; }

    /// <summary>
    /// Status.
    /// </summary>
    [Required]
    public Status Status { get; set; }

    /// <summary>
    /// Estimated time to complete the issue.
    /// </summary>
    [Required]
    public int EstimatedHours { get; set; }

    /// <summary>
    /// The date when the issue was created.
    /// </summary>
    public DateTime CreatedAt { get; init; }

    /// <summary>
    /// The time when the issue was completed.
    /// </summary>
    public DateTime? CompletedAt { get; set; }

    /// <summary>
    /// The date when the issue should have already been completed.
    /// </summary>
    [Required]
    public DateTime Deadline { get; init; }

    /// <summary>
    /// Sub issues.
    /// </summary>
    public virtual ICollection<Issue> SubIssues { get; init; }

    /// <summary>
    /// Parent issue id.
    /// </summary>
    public virtual int? IssueId { get; set; }
}
