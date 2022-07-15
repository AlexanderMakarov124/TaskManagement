using TaskManagement.Domain.Models;

namespace TaskManagement.Web.ViewModels;

/// <summary>
/// Issue view model.
/// </summary>
public class IssuesListViewModel
{
    /// <summary>
    /// Issues.
    /// </summary>
    public IEnumerable<Issue> Issues { get; init; }
}
