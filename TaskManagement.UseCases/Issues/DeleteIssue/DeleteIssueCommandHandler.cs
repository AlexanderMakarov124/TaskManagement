using MediatR;
using TaskManagement.Abstractions.DataAccess;

namespace TaskManagement.UseCases.Issues.DeleteIssue;

/// <summary>
/// Delete issue command handler
/// </summary>
internal class DeleteIssueCommandHandler : AsyncRequestHandler<DeleteIssueCommand>
{
    private readonly IApplicationContext db;

    /// <summary>
    /// Constructor.
    /// </summary>
    public DeleteIssueCommandHandler(IApplicationContext db)
    {
        this.db = db;
    }

    /// <inheritdoc />
    protected override async Task Handle(DeleteIssueCommand request, CancellationToken cancellationToken)
    {
        var issue = await db.Issues.FindAsync(request.Id);

        if (issue != null)
        {
            db.Issues.Remove(issue);
            await db.SaveChangesAsync();
        }
    }
}
