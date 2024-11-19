using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RotasParaOFuturo.Models;
using RotasParaOFuturo.ViewModels;

namespace RotasParaOFuturo.Controllers
{
    public class AdminController : Controller
    {
        private readonly SignInManager<Admin> signInManager;
        private readonly UserManager<Admin> userManager;

        public AdminController(SignInManager<Admin> signInManager, UserManager<Admin> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if(ModelState.IsValid)
            {
                var result = await signInManager.
                    PasswordSignInAsync(model.Email!, model.Password!, model.RememberMe, false);

                if(result.Succeeded)
                {
                    return RedirectToAction("Inicial", "Home");
                }

                ModelState.AddModelError("", "Invalid login atempt");
                return View(model);
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if(ModelState.IsValid)
            {
                Admin admin = new()
                {
                    Nome = model.Nome,
                    UserName = model.Email,
                    Email = model.Email,
                    Endereco = model.Endereco,
                };

                var result = await userManager.CreateAsync(admin, model.Password);

                if(result.Succeeded)
                {
                    await signInManager.SignInAsync(admin, false);
                    return RedirectToAction("Inicial", "Home"); 
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
