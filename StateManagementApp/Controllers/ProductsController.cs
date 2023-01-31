using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StateManagementApp.Models;

namespace StateManagementApp.Controllers;

public class ProductsController : Controller
{
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Details(int id)
    {
        return View();
    }

     
}
