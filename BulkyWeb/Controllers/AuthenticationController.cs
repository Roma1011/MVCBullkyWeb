using System.Security.Claims;
using Bulky.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bulky.Controllers;

public class AuthenticationController:Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;

    public AuthenticationController(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<IActionResult> LoginView()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return View("Login");
        }
    }
    
    
    public IActionResult RegistrationView()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return View("Registration");
        }
    }
    
    public async Task<IActionResult> Login([FromBody]LoginViewModel loginViewModel)
    {
        if(User.Identity.IsAuthenticated)
            return RedirectToAction("Index","Home");
        
        var result =await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, false,false);
        if (!result.Succeeded)
            return BadRequest("Password or login is incorrect");
        
        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index","Home");
    }

    public async Task<IActionResult> Registration(UserInformationViewModel userInformationViewModel)
    {
        if (User.Identity.IsAuthenticated)
            return RedirectToAction("Index", "Home");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        IdentityUser user = new IdentityUser
        {
            Email = userInformationViewModel.Email,
            UserName = userInformationViewModel.Email,
        };

        var claims = new List<Claim>
        {
            new (ClaimTypes.DateOfBirth, userInformationViewModel.DateOfBirth.ToString("yyyy-MM-dd")),
            new (ClaimTypes.Name, userInformationViewModel.FirstName),
            new (ClaimTypes.Surname, userInformationViewModel.LastName),
        };

        var result = await _signInManager.UserManager.CreateAsync(user, userInformationViewModel.Password);

        if (!result.Succeeded)
            return BadRequest(result.Errors.Select(x => x.Description));

        var addClaimsResult = await _signInManager.UserManager.AddClaimsAsync(user, claims);

        if (!addClaimsResult.Succeeded)
            return BadRequest(addClaimsResult.Errors.Select(x => x.Description));

        await _signInManager.SignInAsync(user, false);

        return RedirectToAction("Index", "Home");
    }

    
}