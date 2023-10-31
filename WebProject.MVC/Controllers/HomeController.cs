using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebProject.Entities.Dtos;
using WebProject.Entities.Entities.Identity;
using WebProject.MVC.Extensions;
using WebProject.MVC.Models;

namespace WebProject.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _UserManager;
        private readonly SignInManager<User> _signInManager;



        public HomeController(ILogger<HomeController> logger, UserManager<User> UserManager, SignInManager<User> signInManager)
        {
            _logger = logger;
            _UserManager = UserManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginDto request)
        {
            string  returnUrl= Url.Action("Index", "Member");
            var mail = request.Email;
            var hasUser = await _UserManager.FindByEmailAsync(mail);
            if (hasUser == null)
            {
                ModelState.AddModelError(string.Empty, "Email veya şifre yanlış");
                return View();

            }

            var signInResult = await _signInManager.PasswordSignInAsync(hasUser, request.Password!, request.RememberMe, true);
            if (signInResult.Succeeded)
            {
                return Redirect(returnUrl!);


            }

            if (signInResult.IsLockedOut)
            {

                ModelState.AddModelErrorList(new List<string>() { "3 dakika boyunca giriş yapamazsınız" });
                return View();
            }




            var unsuccesCount = await _UserManager.GetAccessFailedCountAsync(hasUser);

            ModelState.AddModelErrorList(new List<string>() { "Email Veya Şifre yanlış", $"Başarısız Giriş Sayısı={unsuccesCount}" });

            return View();



        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}