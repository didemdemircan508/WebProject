using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebProject.Entities.Dtos;
using WebProject.Entities.Entities.Entity;
using WebProject.Entities.Entities.Identity;
using WebProject.Services.Abstract;

namespace WebProject.MVC.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IUserPrimeNumberService _userPrimeNumberService;
      


        public MemberController(SignInManager<User> signInManager, UserManager<User> userManager, IUserPrimeNumberService userPrimeNumberService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userPrimeNumberService = userPrimeNumberService;
          
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();


        }
        [HttpGet]
        public IActionResult AddCalculate()
        {
            return View();


        }

        [HttpPost]
        public async Task<IActionResult> AddCalculate(UserPrimeAddDto userPrimeAddDto)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var hasUser = await _userManager.FindByIdAsync(userId);

            if (hasUser == null)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı Sistemde bulunmamaktadır");
                return View();

            }

            userPrimeAddDto.UserId = Convert.ToInt16(userId) ;
            await _userPrimeNumberService.Add(userPrimeAddDto);
            TempData["SuccessMessage"] = "Kayıt İşlemi Başarılıdır"; ;
            ModelState.Clear();
            return View();
         

        }
        [Authorize(Roles="Admin")]
        [HttpGet]

        public async  Task<IActionResult> GetList()
        {
           var list= await _userPrimeNumberService.GetAll();
            return View(list);


        }




    }
}
