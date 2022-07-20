namespace TaskManagement.Domain.Exceptions;

/// <summary>
/// Raises when requested issue does not exist in the database.
/// </summary>
public class IssueNotFoundException : Exception
{
    /// <summary>
    /// Initialize the exception with a message.
    /// </summary>
    /// <param name="message">Message that describes the exception.</param>
    public IssueNotFoundException(string message) : base(message)
    {
    }
}
