namespace TaskManagement.Domain.Models;

/// <summary>
/// Issue status.
/// </summary>
public enum Status
{
    /// <summary>
    /// Initial assigned status.
    /// </summary>
    Assigned = 1,

    /// <summary>
    /// Work on the issue is underway.
    /// </summary>
    InProgress = 2,

    /// <summary>
    /// Work on the issue was cancelled.
    /// </summary>
    Stopped = 3,

    /// <summary>
    /// Work on the issue was completed.
    /// </summary>
    Completed = 4
}
