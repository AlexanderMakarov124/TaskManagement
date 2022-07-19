namespace TaskManagement.Domain.Exceptions;
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
