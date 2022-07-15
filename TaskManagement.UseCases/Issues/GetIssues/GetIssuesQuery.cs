using MediatR;
using TaskManagement.Domain.Models;

namespace TaskManagement.UseCases.Issues.GetIssues;

/// <summary>
/// Get issues query.
/// </summary>
public record GetIssuesQuery : IRequest<IEnumerable<Issue>>;