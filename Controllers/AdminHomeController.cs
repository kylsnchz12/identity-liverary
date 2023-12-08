using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using liveraryIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using liveraryIdentity.Data.Interfaces;


namespace liveraryIdentity.Controllers;

public class AdminHomeController : Controller
{
    private readonly ILogger<AdminHomeController> _logger;
    private readonly ITrainingRepository _trainingRepository;
    private readonly ICategoryRepository _categoryRepository;

    public AdminHomeController(ILogger<AdminHomeController> logger, ITrainingRepository trainingRepository, ICategoryRepository categoryRepository)
    {
        _logger = logger;
        _trainingRepository = trainingRepository;
        _categoryRepository = categoryRepository;
    }

    [Authorize(Roles = "SuperAdmin, Admin")]
    public IActionResult Index()
    {
        var categories = _categoryRepository.Categories;
        var trainings = _trainingRepository.Trainings;

        var viewModel = new HomeViewModel
        {
            Trainings = trainings,
            Categories = categories
        };
        return View(viewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
