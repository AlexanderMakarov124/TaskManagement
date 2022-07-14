using Microsoft.AspNetCore.Mvc;
using TaskManagement.Domain.Models;
using TaskManagement.Web.ViewModels;

namespace TaskManagement.Web.Controllers;

/// <summary>
/// Issue controller.
/// </summary>
public class IssueController : Controller
{
    /// <summary>
    /// Index view.
    /// </summary>
    /// <returns>View.</returns>
    public IActionResult Index()
    {
        var testData = new List<Issue>
        {
            new Issue
            {
                Name = "test1"
            },
            new Issue
            {
                Name = "test2"
            }
        };
        var viewModel = new IssueViewModel { Issues = testData };
        return View(viewModel);
    }
}
