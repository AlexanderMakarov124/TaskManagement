using MediatR;
using TaskManagement.Domain.Models;

namespace TaskManagement.UseCases.Issues.FindIssueById;

/// <summary>
/// Find issue by id query.
/// </summary>
/// <param name="Id">Issue id.</param>
public record FindIssueByIdQuery(int Id) : IRequest<Issue>;