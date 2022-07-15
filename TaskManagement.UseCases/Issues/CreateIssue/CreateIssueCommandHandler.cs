using MediatR;
using TaskManagement.Abstractions.DataAccess;
using TaskManagement.Domain.Models;

namespace TaskManagement.UseCases.Issues.CreateIssue;

/// <summary>
/// Create issue command handler.
/// </summary>
internal class CreateIssueCommandHandler : AsyncRequestHandler<CreateIssueCommand>
{
    private readonly IApplicationContext db;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateIssueCommandHandler(IApplicationContext db)
    {
        this.db = db;
    }

    /// <inheritdoc />
    protected override async Task Handle(CreateIssueCommand request, CancellationToken cancellationToken)
    {
        var issue = new Issue
        {
            Name = request.Name!,
            Description = request.Description,
            Executors = request.Executors,
            Status = request.Status,
            EstimatedHours = request.EstimatedHours,
            Deadline = request.Deadline
        };

        db.Issues.Add(issue);
        await db.SaveChangesAsync();
    }
}
