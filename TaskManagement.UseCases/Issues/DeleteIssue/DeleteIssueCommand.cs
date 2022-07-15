using MediatR;

namespace TaskManagement.UseCases.Issues.DeleteIssue;

/// <summary>
/// Delete issue command.
/// </summary>
/// <param name="Id">Issue id.</param>
public record DeleteIssueCommand(int Id) : IRequest;
