﻿using System.Diagnostics;
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
    private readonly ITopicRepository _topicRepository;

    private readonly IResourceRepository _resourceRepository;

    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ITrainingRepository trainingRepository, ICategoryRepository categoryRepository, ITopicRepository topicRepository, IResourceRepository resourceRepository, ApplicationDbContext context)
    {
        _logger = logger;
        _trainingRepository = trainingRepository;
        _categoryRepository = categoryRepository;
        _topicRepository = topicRepository;
        _context = context;
        _resourceRepository = resourceRepository;
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

    [HttpGet]
    public IActionResult Search(string searchTerm)
    {
        var trainings = _trainingRepository.GetTrainingsByTitle(searchTerm);
        var categories = _categoryRepository.GetCategoriesByTitle(searchTerm);
        
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
        var trainings = _trainingRepository.Trainings;
        if (category == null){
            return NotFound();
        }

        var viewModel = new CategoryViewModel
        {
            Training = trainings,
            Categories = category
        };

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Training(int id)
    {
        var training = _trainingRepository.GetTrainingById(id);
        var categories = _categoryRepository.Categories;
        var topics = _topicRepository.GetAllTopics();
        var resource = _resourceRepository.GetAllResources();

        if (training == null){
            return NotFound();
        }

        var viewModel = new TrainingViewModel
        {
            Training = training,
            Categories = categories,
            Topics = topics,
            Resources = resource
        };

        return View(viewModel);
    }

    public IActionResult DownloadFile(string filePath)
    {
        string permittedDirectory = "/Users/kyle/Desktop/GitHub/identity-liverary/wwwroot/images/Resources/";
        string fullPath = Path.Combine(permittedDirectory, filePath);

        if (System.IO.File.Exists(fullPath))
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, "application/pdf", filePath);
        }
        else
        {
            return NotFound(); 
        }
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
