using MediatR;
using TaskManagement.Abstractions.DataAccess;
using TaskManagement.Domain.Exceptions;

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
            if (issue.SubIssues.Any())
            {
                foreach (var subIssue in issue.SubIssues)
                {
                    subIssue.IssueId = null;
                }
            }
            db.Issues.Remove(issue);
            await db.SaveChangesAsync(cancellationToken);
        }
        else
        {
            throw new IssueNotFoundException($"Issue with id {request.Id} was not found.");
        }
    }
}
