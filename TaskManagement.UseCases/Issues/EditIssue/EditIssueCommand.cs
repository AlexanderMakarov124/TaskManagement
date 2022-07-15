using MediatR;
using TaskManagement.Domain.Dtos;

namespace TaskManagement.UseCases.Issues.EditIssue;

/// <summary>
/// Edit issue command.
/// </summary>
/// <param name="IssueDto">Issue DTO.</param>
public record EditIssueCommand(IssueDto IssueDto) : IRequest;