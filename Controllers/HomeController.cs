using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using liveraryIdentity.Models;
using liveraryIdentity.Data.Interfaces;

namespace liveraryIdentity.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ITrainingRepository _trainingRepository;

    public HomeController(ILogger<HomeController> logger, ICategoryRepository categoryRepository, ITrainingRepository trainingRepository)
    {
        _logger = logger;
        _categoryRepository = categoryRepository;
        _trainingRepository = trainingRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var trainings = _trainingRepository.Trainings;
        return View(trainings);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Category()
    {
        return View();
    }

    public IActionResult Training()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
