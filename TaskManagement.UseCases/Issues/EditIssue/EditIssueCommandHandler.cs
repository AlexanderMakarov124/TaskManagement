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

        issue = mapper.Map<Issue>(request.IssueDto);

        db.Issues.Update(issue);
        await db.SaveChangesAsync(cancellationToken);
    }
}
