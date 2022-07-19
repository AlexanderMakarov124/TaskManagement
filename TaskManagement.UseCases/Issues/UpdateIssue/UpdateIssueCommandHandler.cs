using AutoMapper;
using MediatR;
using TaskManagement.Abstractions.DataAccess;
using TaskManagement.Domain.Models;

namespace TaskManagement.UseCases.Issues.UpdateIssue;

/// <summary>
/// Update issue command handler.
/// </summary>
internal class UpdateIssueCommandHandler : AsyncRequestHandler<UpdateIssueCommand>
{
    private readonly IApplicationContext db;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public UpdateIssueCommandHandler(IApplicationContext db, IMapper mapper)
    {
        this.db = db;
        this.mapper = mapper;
    }

    /// <inheritdoc />
    protected override async Task Handle(UpdateIssueCommand request, CancellationToken cancellationToken)
    {
        var issue = await db.Issues.FindAsync(request.IssueDto.Id);

        var issueDto = request.IssueDto with
        {
            IssueId = issue!.IssueId,
            CreatedAt = issue.CreatedAt,
            CompletedAt = issue.CompletedAt
        };
        if (issue.Status == Status.InProgress && issueDto.Status == Status.Completed.ToString())
        {
            if (SubIssuesAbleToComplete(issue))
            {
                issueDto = issueDto with
                {
                    CompletedAt = DateTime.UtcNow
                };
                CompleteSubIssues(issue);
            }
            else
            {
                issueDto = issueDto with
                {
                    Status = issue.Status.ToString()
                };
            }
        }
        else if (issue.Status == Status.Completed && issue.Status.ToString() != issueDto.Status)
        {
            issueDto = issueDto with
            {
                CompletedAt = null
            };
        }
        var editedIssue = mapper.Map<Issue>(issueDto);

        db.Entry(issue).CurrentValues.SetValues(editedIssue);
        await db.SaveChangesAsync(cancellationToken);
    }

    private void CompleteSubIssues(Issue issue)
    {
        foreach (var subIssue in issue.SubIssues)
        {
            subIssue.Status = Status.Completed;
            subIssue.CompletedAt = DateTime.UtcNow;
            CompleteSubIssues(subIssue);
        }
    }

    private bool SubIssuesAbleToComplete(Issue issue)
    {
        foreach (var subIssue in issue.SubIssues)
        {
            if (subIssue.Status != Status.InProgress || !SubIssuesAbleToComplete(subIssue))
            {
                return false;
            }
        }

        return true;
    }
}
