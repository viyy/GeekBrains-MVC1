using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebStore.DomainModels;
using WebStore.DomainModels.Entities.Classes;
using WebStore.Models;

namespace WebStore.Controllers
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
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _signInManager.PasswordSignInAsync(model.UserName,
                    model.Password,
                    model.RememberMe,
                    lockoutOnFailure: false);//Проверяем логин/пароль пользователя

                if (loginResult.Succeeded)//если проверка успешна
                {
                    if (Url.IsLocalUrl(model.ReturnUrl))//и returnUrl - локальный
                    {
                        return Redirect(model.ReturnUrl);//перенаправляем туда, откуда пришли
                    }

                    return RedirectToAction("Index", "Home");//иначе на главную
                }

            }
            ModelState.AddModelError("", "Вход невозможен");//говорим пользователю, что вход невозможен
            return View(model);
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View(new AccountViewModel());
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AccountViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = new User { UserName = model.UserName };//создаем сущность пользователь
            var createResult = await _userManager.CreateAsync(user, model.Password);//используем менеджер для создания
            if (createResult.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);//если успешно - производим логин
                await _userManager.AddToRoleAsync(user, WebStoreConstants.Roles.User);
                RedirectToAction("Index", "Home");
            }
            else//иначе
            {
                foreach (var identityError in createResult.Errors)//выводим ошибки
                {
                    ModelState.AddModelError("", identityError.Description);
                }
            }
            return View(model);
        }


    }
}