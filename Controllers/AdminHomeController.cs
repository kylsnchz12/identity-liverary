using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using liveraryIdentity.Models;
using Microsoft.AspNetCore.Authorization;


namespace liveraryIdentity.Controllers;

public class AdminHomeController : Controller
{
    private readonly ILogger<AdminHomeController> _logger;

    public AdminHomeController(ILogger<AdminHomeController> logger)
    {
        _logger = logger;
    }

    [Authorize(Roles = "SuperAdmin, Admin")]
    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
