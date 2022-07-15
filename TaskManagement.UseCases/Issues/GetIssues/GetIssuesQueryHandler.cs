using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Abstractions.DataAccess;
using TaskManagement.Domain.Models;

namespace TaskManagement.UseCases.Issues.GetIssues;

/// <summary>
/// Get issues query handler.
/// </summary>
internal class GetIssuesQueryHandler : IRequestHandler<GetIssuesQuery, IEnumerable<Issue>>
{
    private readonly IApplicationContext db;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetIssuesQueryHandler(IApplicationContext db)
    {
        this.db = db;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Issue>> Handle(GetIssuesQuery request, CancellationToken cancellationToken)
    {
        return await db.Issues.ToListAsync(cancellationToken);
    }
}
