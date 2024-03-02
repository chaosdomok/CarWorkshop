using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.MVC.Models;

namespace CarWorkshop.MVC.Controllers;

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

    public IActionResult NoAccess()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        var model = new List<Person>()
        {
            new Person()
            {
                FirstName = "Jakub",
                LastName = "Kozera"
            },
            new Person()
            {
                FirstName = "Adam",
                LastName = "Ma³ysz"
            }
        };

        return View(model);
    }

    public IActionResult About()
    {
        var model = new About()
        {
                Title = "About",
                Description = "Pierwszy Projekt",
                Tags = new List<string>(){"auto", "app", "Free"}
        };
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
