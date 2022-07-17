using MediatR;
using TaskManagement.Domain.Dtos;

namespace TaskManagement.UseCases.Issues.CreateIssue;

/// <summary>
/// Create issue command.
/// </summary>
/// <param name="IssueDto">Issue DTO.</param>
/// <param name="Id">Parent issue id.</param>
public record CreateIssueCommand(IssueDto IssueDto, int? Id) : IRequest;