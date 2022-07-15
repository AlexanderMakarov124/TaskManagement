using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.UseCases.Issues.CreateIssue;
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
    /// Index view. Contains issues.
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

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateIssueCommand command, CancellationToken cancellationToken)
    {
        await mediator.Send(command, cancellationToken);
        return RedirectToAction(nameof(Index));
    }
}
