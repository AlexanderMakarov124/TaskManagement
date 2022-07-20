using MediatR;
using TaskManagement.Domain.Dtos;

namespace TaskManagement.UseCases.Issues.CreateIssue;

/// <summary>
/// Create issue command.
/// </summary>
/// <param name="IssueDto">Issue DTO.</param>
/// <param name="ParentId">Parent issue id.</param>
public record CreateIssueCommand(IssueDto IssueDto, int? ParentId) : IRequest;