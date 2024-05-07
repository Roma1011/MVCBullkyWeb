using Bulky.Data;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bulky.Controllers;

public class CategoryController : Controller
{
    private readonly Context _context;
    public CategoryController(Context context)
        => _context = context;
    
    public IActionResult Index()
    {

        ViewData["Category"]=_context.Categories.ToList();
        return View();
    }
    
    [HttpGet]
    public IActionResult GetCategoryById(int id)
    {
        ArgumentNullException.ThrowIfNull(nameof(id));
        
        var category = _context.Categories.FirstOrDefault(x=>x.Id==id);
        
        Response.StatusCode = category != null ? 200 : 404;
        
        ViewData["StatusCode"] = Response.StatusCode;
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public IActionResult CreateCategory(Category category)
    {
        ArgumentNullException.ThrowIfNull(nameof(category));
        
        var entry = _context.Categories.Add(category);

        if (entry.State == EntityState.Added && _context.SaveChanges() > 0)
            Response.StatusCode = 200;
        else
            Response.StatusCode = 400;
        
        
        ViewData["StatusCode"] = Response.StatusCode;
        return RedirectToAction("Index");
    }
    
    [HttpPut]
    public IActionResult EditCategory(Category category)
    {
        ArgumentNullException.ThrowIfNull(nameof(category));
        
        var entry=_context.Update(category);
        
        if (entry.State == EntityState.Modified && _context.SaveChanges() > 0)
            Response.StatusCode = 200;
        else
            Response.StatusCode = 400;
    
        
        ViewData["StatusCode"] = Response.StatusCode;
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DeleteCategory(int id)
    {
        var category =_context.Categories.FirstOrDefault(x=>x.Id==id);
        if (category == null)
        {
            Response.StatusCode = 404;
            return RedirectToAction("Index");
        }
        
        var entry=_context.Categories.Remove(category);
        
        if (entry.State == EntityState.Deleted && _context.SaveChanges() > 0)
            Response.StatusCode = 200;

        ViewData["StatusCode"] = Response.StatusCode;
        return RedirectToAction("Index");
    }

}