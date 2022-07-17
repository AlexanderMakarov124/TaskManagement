using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Abstractions.DataAccess;
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
        var issue = mapper.Map<Issue>(request.IssueDto);

        if (request.Id != null)
        {
            var parentIssue = db.Issues
                .Where(i => i.Id == request.Id)
                .Include(i => i.SubIssues)
                .FirstOrDefault();
            parentIssue!.SubIssues.Add(issue);
        }

        db.Issues.Add(issue);
        await db.SaveChangesAsync(cancellationToken);
    }
}
