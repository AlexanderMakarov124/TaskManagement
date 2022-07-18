using MediatR;
using TaskManagement.Abstractions.DataAccess;
using TaskManagement.Domain.Models;

namespace TaskManagement.UseCases.Issues.FindIssueById;

/// <summary>
/// Find issue by id query handler.
/// </summary>
internal class FindIssueByIdQueryHandler : IRequestHandler<FindIssueByIdQuery, Issue>
{
    private readonly IApplicationContext db;

    /// <summary>
    /// Constructor.
    /// </summary>
    public FindIssueByIdQueryHandler(IApplicationContext db)
    {
        this.db = db;
    }

    /// <inheritdoc />
    public async Task<Issue> Handle(FindIssueByIdQuery request, CancellationToken cancellationToken)
    {
        var issue = await db.Issues.FindAsync(request.Id);

        return issue;
    }
}
