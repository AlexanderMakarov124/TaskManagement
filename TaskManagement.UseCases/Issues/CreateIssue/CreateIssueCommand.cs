using MediatR;
using TaskManagement.Domain.Dtos;
using TaskManagement.Domain.Models;

namespace TaskManagement.UseCases.Issues.CreateIssue;

/// <summary>
/// Create issue command.
/// </summary>
/// <param name="IssueDto">Issue DTO.</param>
public record CreateIssueCommand(IssueDto IssueDto) : IRequest;