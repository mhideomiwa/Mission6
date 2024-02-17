using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6.Models;

namespace Mission6.Controllers;

public class HomeController : Controller
{
    private MovieContext _context;
    public HomeController(MovieContext context) //Constructor
    {
        _context = context;
    }
    
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AboutJoel()
    {
        return View();
    }
    
    public IActionResult MovieCollection()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult MovieCollection(MovieForm movie)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie); //Add to database
                _context.SaveChanges(); //Save changes
                return View("Confirmation", movie);
            }
            else
            {
                return View("Error");
            }
        }
        catch (Exception e)
        {
            return View("Error");
        }
    }
    
    
}