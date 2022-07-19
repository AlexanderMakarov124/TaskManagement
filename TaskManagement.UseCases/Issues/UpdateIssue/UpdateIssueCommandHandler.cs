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
            IssueId = issue.IssueId,
            CreatedAt = issue.CreatedAt,
            CompletedAt = issue.CompletedAt
        };
        if (issue.Status.ToString() != issueDto.Status && issueDto.Status == Status.Completed.ToString())
        {
            issueDto = issueDto with
            {
                CompletedAt = DateTime.UtcNow
            };
        }
        else if (issue.Status.ToString() != issueDto.Status && issue.Status == Status.Completed)
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
}
