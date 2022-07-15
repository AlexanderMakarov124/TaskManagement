using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Domain.Dtos;
using TaskManagement.UseCases.Issues.CreateIssue;
using TaskManagement.UseCases.Issues.DeleteIssue;
using TaskManagement.UseCases.Issues.GetIssues;
using TaskManagement.Web.ViewModels;

namespace TaskManagement.Web.Controllers;

/// <summary>
/// Issue controller.
/// </summary>
public class IssueController : Controller
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public IssueController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    /// <summary>
    /// GET: Index view. Contains issues.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>View.</returns>
    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var issues = await mediator.Send(new GetIssuesQuery(), cancellationToken);

        var viewModel = new IssuesListViewModel { Issues = issues };
        return View(viewModel);
    }

    /// <summary>
    /// GET: Create view.
    /// </summary>
    /// <returns>View.</returns>
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    /// <summary>
    /// POST: Creates issue.
    /// </summary>
    /// <param name="issueDto">Issue DTO.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>Redirect to index page.</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] IssueDto issueDto, CancellationToken cancellationToken)
    {
        await mediator.Send(new CreateIssueCommand(issueDto), cancellationToken);

        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// POST: Deletes issue.
    /// </summary>
    /// <param name="id">Issue id.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>Redirect to index page.</returns>
    [HttpPost]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteIssueCommand(id), cancellationToken);

        return RedirectToAction(nameof(Index));
    }
}
