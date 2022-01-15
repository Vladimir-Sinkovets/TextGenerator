using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebIdeaGeneration.Models;
using WebIdeaGeneration.Models.ViewModels;

namespace WebIdeaGeneration.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid == true)
            {
                User user = new User { Email = model.Email, UserName = model.Name }; // создаем модель пользователя
                var result = await _userManager.CreateAsync(user, model.Password); // сохраняем нового пользователя в базу
                if(result.Succeeded) // если сохранение прошло успешно
                {
                    await _signInManager.SignInAsync(user, false); // входим в аккаунт. Записываются кукизы. Второй параметр указывает надо ли сохранять на длительное время
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description); // в случае ошибки отправить соответствующий код
                    }
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, true);
                if (result.Succeeded == true)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    
                    ModelState.AddModelError(string.Empty, result.ToString());
                }
            }
            return View(model);
        }
    }
}
