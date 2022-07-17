using TaskManagement.Domain.Dtos;

namespace TaskManagement.Web.ViewModels;

public class CreateIssueViewModel
{
    public IssueDto Issue { get; init; }

    public int Id { get; init; }
}
