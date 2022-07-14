using TaskManagement.Domain.Models;

namespace TaskManagement.Web.ViewModels;

/// <summary>
/// Issue view model.
/// </summary>
public class IssueViewModel
{
    /// <summary>
    /// Issues.
    /// </summary>
    public IEnumerable<Issue> Issues { get; init; }
}
