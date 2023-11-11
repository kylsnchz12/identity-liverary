using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using liveraryIdentity.Models;
using liveraryIdentity.Data.Interfaces;
using liveraryIdentity.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace liveraryIdentity.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITrainingRepository _trainingRepository;
    private readonly ICategoryRepository _categoryRepository;

    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ITrainingRepository trainingRepository, ICategoryRepository categoryRepository, ApplicationDbContext context)
    {
        _logger = logger;
        _trainingRepository = trainingRepository;
        _categoryRepository = categoryRepository;
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {   
        // var categoriesId = _context.Categories.ToList();
        // ViewBag.Categories = categoriesId;
        var categories = _categoryRepository.Categories;
        var trainings = _trainingRepository.Trainings;

        var viewModel = new HomeViewModel
        {
            Trainings = trainings,
            Categories = categories
        };
        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Category(int id)
    {
        var category = _categoryRepository.GetCategoryById(id);
        if (category == null){
            return NotFound();
        }
        return View(category);
    }

    [HttpGet]
    public IActionResult Training(int id)
    {
        var training = _trainingRepository.GetTrainingById(id);
        if (training == null){
            return NotFound();
        }

        return View(training);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
