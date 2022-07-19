using MediatR;
using TaskManagement.Domain.Dtos;

namespace TaskManagement.UseCases.Issues.UpdateIssue;

/// <summary>
/// Update issue command.
/// </summary>
/// <param name="IssueDto">Issue DTO.</param>
public record UpdateIssueCommand(IssueDto IssueDto) : IRequest;