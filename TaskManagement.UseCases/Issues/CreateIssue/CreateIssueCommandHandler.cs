using AutoMapper;
using MediatR;
using TaskManagement.Abstractions.DataAccess;
using TaskManagement.Domain.Exceptions;
using TaskManagement.Domain.Models;

namespace TaskManagement.UseCases.Issues.CreateIssue;

/// <summary>
/// Create issue command handler.
/// </summary>
internal class CreateIssueCommandHandler : AsyncRequestHandler<CreateIssueCommand>
{
    private readonly IApplicationContext db;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateIssueCommandHandler(IApplicationContext db, IMapper mapper)
    {
        this.db = db;
        this.mapper = mapper;
    }

    /// <inheritdoc />
    protected override async Task Handle(CreateIssueCommand request, CancellationToken cancellationToken)
    {
        var issueDto = request.IssueDto with
        {
            CreatedAt = DateTime.UtcNow
        };
        var issue = mapper.Map<Issue>(issueDto);

        if (request.ParentId != null)
        {
            var parentIssue = await db.Issues.FindAsync(request.ParentId);

            if (parentIssue != null)
            {
                parentIssue!.SubIssues.Add(issue);
            }
            else
            {
                throw new IssueNotFoundException($"Issue with id {request.ParentId} was not found.");
            }
        }

        db.Issues.Add(issue);
        await db.SaveChangesAsync(cancellationToken);
    }
}
