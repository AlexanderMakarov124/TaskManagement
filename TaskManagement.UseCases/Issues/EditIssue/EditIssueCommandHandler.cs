using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        var issue = mapper.Map<Issue>(request.IssueDto);

        db.Issues.Add(issue);
        db.Entry(issue).State = EntityState.Modified;
        await db.SaveChangesAsync(cancellationToken);
    }
}
