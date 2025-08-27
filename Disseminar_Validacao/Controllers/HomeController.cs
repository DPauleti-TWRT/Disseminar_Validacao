using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Disseminar_Validacao.Models;

namespace Disseminar_Validacao.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        var exceptionHandlerPathFeature = HttpContext.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature>();

        if (exceptionHandlerPathFeature != null)
        {

            _logger.LogError(
                exceptionHandlerPathFeature.Error,
                "An error occurred while processing the request at {Path}",
                exceptionHandlerPathFeature.Path);
        }

        var viewModel = new ErrorViewModel
        {
            RequestId = HttpContext.TraceIdentifier,
            ErrorMessage = "An unexpected error occurred. Please try again later."
        };

        return View(viewModel);
    }
}
}
