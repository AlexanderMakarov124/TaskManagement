using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using TaskManagement.Domain.Dtos;
using TaskManagement.Domain.Exceptions;
using TaskManagement.Domain.Models;
using TaskManagement.UseCases.Issues.CreateIssue;
using TaskManagement.UseCases.Issues.DeleteIssue;
using TaskManagement.UseCases.Issues.FindIssueById;
using TaskManagement.UseCases.Issues.GetIssues;
using TaskManagement.UseCases.Issues.UpdateIssue;
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
    /// GET: Issues list view.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>View.</returns>

    [HttpGet("List")]
    public async Task<IActionResult> List(CancellationToken cancellationToken)
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

        await GetSumHoursAsync(issue, cancellationToken);

        return View(issue);
    }

    private async Task GetSumHoursAsync(Issue issue, CancellationToken cancellationToken)
    {
        var sumHours = 0;
        if (issue.SubIssues.Any())
        {
            foreach (var subIssue in issue.SubIssues)
            {
                await GetSumHoursAsync(subIssue, cancellationToken);
                sumHours += subIssue.EstimatedHours;
            }
        }
        else
        {
            sumHours = issue.EstimatedHours;
        }
        issue.EstimatedHours = sumHours;
        await mediator.Send(new UpdateIssueCommand(mapper.Map<IssueDto>(issue)), cancellationToken);
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
        try
        {
            if (ModelState.IsValid)
            {
                await mediator.Send(new CreateIssueCommand(issueDto, id), cancellationToken);
            }
            else
            {
                return View(issueDto);
            }
        }
        catch (IssueNotFoundException ex)
        {
            ViewData["Exception"] = ex.Message;
            return View(issueDto);
        }

        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// DELETE: Deletes issue.
    /// </summary>
    /// <param name="id">Issue id.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>No content status code.</returns>
    [HttpDelete]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteIssueCommand(id), cancellationToken);

        return NoContent();
    }

    /// <summary>
    /// GET: Edit view.
    /// </summary>
    /// <returns>View.</returns>
    [HttpGet]
    public async Task<IActionResult> Edit([FromRoute] int id, CancellationToken cancellationToken)
    {
        Issue issue;
        try
        {
            issue = await mediator.Send(new FindIssueByIdQuery(id), cancellationToken);
        }
        catch (IssueNotFoundException ex)
        {
            return NotFound(ex.Message);
        }

        var issueDto = mapper.Map<IssueDto>(issue);

        return View(issueDto);
    }

    /// <summary>
    /// PUT: Edits issue.
    /// </summary>
    /// <param name="issueDto">Issue DTO.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>No content status code.</returns>
    [HttpPut("Edit")]
    public async Task<IActionResult> Edit([FromForm] IssueDto issueDto, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
        {
            await mediator.Send(new UpdateIssueCommand(issueDto), cancellationToken);
        }
        else
        {
            return View(issueDto);
        }

        return NoContent();
    }

    [HttpPost]
    public IActionResult SetLanguage(string culture, string returnUrl)
    {
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
        );

        return LocalRedirect(returnUrl);
    }
}
