using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Domain.Dtos;
using TaskManagement.UseCases.Issues.CreateIssue;
using TaskManagement.UseCases.Issues.DeleteIssue;
using TaskManagement.UseCases.Issues.EditIssue;
using TaskManagement.UseCases.Issues.FindIssueById;
using TaskManagement.UseCases.Issues.GetIssues;
using TaskManagement.Web.ViewModels;

namespace TaskManagement.Web.Controllers;

/// <summary>
/// Issue controller.
/// </summary>
public class IssueController : Controller
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public IssueController(IMediator mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
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
    /// GET: Information view about the issue.
    /// </summary>
    /// <param name="id">Issue id.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>View.</returns>
    [HttpGet("Issues/{id:int}")]
    public async Task<IActionResult> Info([FromRoute] int id, CancellationToken cancellationToken)
    {
        var issue = await mediator.Send(new FindIssueByIdQuery(id), cancellationToken);

        return View(issue);
    }

    /// <summary>
    /// GET: Create view.
    /// </summary>
    /// <returns>View.</returns>
    [HttpGet("Create/{id:int?}")]
    public IActionResult Create()
    {
        return View();
    }

    /// <summary>
    /// POST: Creates issue.
    /// </summary>
    /// <param name="issueDto">Issue DTO.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <param name="id">Optional parameter. When you put it, you will create sub issue.</param>
    /// <returns>Redirect to index page.</returns>
    [HttpPost("Create/{id:int?}")]
    public async Task<IActionResult> Create([FromForm] IssueDto issueDto, CancellationToken cancellationToken, [FromRoute] int? id = null)
    {
        await mediator.Send(new CreateIssueCommand(issueDto, id), cancellationToken);

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

    /// <summary>
    /// GET: Edit view.
    /// </summary>
    /// <returns>View.</returns>
    [HttpGet]
    public async Task<IActionResult> Edit([FromRoute] int id, CancellationToken cancellationToken)
    {
        var issue = await mediator.Send(new FindIssueByIdQuery(id), cancellationToken);

        var issueDto = mapper.Map<IssueDto>(issue);

        return View(issueDto);
    }

    /// <summary>
    /// POST: Edits issue.
    /// </summary>
    /// <param name="issueDto">Issue DTO.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>Redirect to index page.</returns>
    [HttpPost]
    public async Task<IActionResult> Edit([FromForm] IssueDto issueDto, CancellationToken cancellationToken)
    {
        await mediator.Send(new EditIssueCommand(issueDto), cancellationToken);

        return RedirectToAction(nameof(Index));
    }
}
