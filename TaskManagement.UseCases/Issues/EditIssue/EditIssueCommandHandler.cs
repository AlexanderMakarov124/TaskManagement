using AutoMapper;
using MediatR;
using TaskManagement.Abstractions.DataAccess;
using TaskManagement.Domain.Models;

namespace TaskManagement.UseCases.Issues.EditIssue;
internal class EditIssueCommandHandler : AsyncRequestHandler<EditIssueCommand>
{
    private readonly IApplicationContext db;
    private readonly IMapper mapper;

    public EditIssueCommandHandler(IApplicationContext db, IMapper mapper)
    {
        this.db = db;
        this.mapper = mapper;
    }

    protected override async Task Handle(EditIssueCommand request, CancellationToken cancellationToken)
    {
        var issue = await db.Issues.FindAsync(request.IssueDto.Id);

        var issueDto = request.IssueDto with
        {
            IssueId = issue.IssueId
        };
        var editedIssue = mapper.Map<Issue>(issueDto);

        db.Entry(issue).CurrentValues.SetValues(editedIssue);
        await db.SaveChangesAsync(cancellationToken);
    }
}
