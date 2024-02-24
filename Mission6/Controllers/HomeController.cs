using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    
    public IActionResult MovieForm()
    {
        ViewBag.Categories = _context.Categories
            .ToList();
        
        return View(new MovieForm());
    }
    
    

    [HttpPost]
    public IActionResult MovieForm(MovieForm movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie); //Add to database
            _context.SaveChanges(); //Save changes
            return View("Confirmation", movie);
        }
        else
        {
            ViewBag.Categories = _context.Categories
                .ToList();
            ViewBag.Movie = movie;
            return View(movie);
        }
    }
    
    [HttpGet]
    public IActionResult MovieCollection()
    {
        var movieList = _context.Movies
            .Include(movie => movie.Category)
            .OrderBy(movie => movie.Title)
            .ToList();
        
        return View(movieList);
    }
    
    
    [HttpGet]
    public IActionResult EditMovie(int id)
    {
        MovieForm movieEdit = _context.Movies
            .Single(m => m.MovieId == id);
           
        
        ViewBag.Categories = _context.Categories
            .ToList();
        
        return View("MovieForm", movieEdit);
    }
    
    [HttpPost]
    public IActionResult EditMovie(MovieForm movie)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();
                return RedirectToAction("MovieCollection");
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
    
    [HttpGet]
    public IActionResult DeleteMovie(int id)
    {
        MovieForm movie = _context.Movies
            .Single(m => m.MovieId == id);
        
        return View(movie);
    }
    
    [HttpPost]
    public IActionResult DeleteMovie(MovieForm movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        
        return RedirectToAction("MovieCollection");
    }
    
}