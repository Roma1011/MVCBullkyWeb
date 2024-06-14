using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bulky.Controllers;

public class UserController:Controller
{
    
    [Authorize]
    [HttpGet]
    public IActionResult MyProfile()
    {
        return View();
    }
    
}