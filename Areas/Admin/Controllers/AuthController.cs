using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Areas.Admin.Models;
using Portfolio.Areas.Admin.Models.RequestModels;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserRequestModel userRequestModel)
        {
            var checkUsername = await _userManager.FindByNameAsync(userRequestModel.Username);
            if (checkUsername is not null)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(checkUsername, userRequestModel.Password, false, false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "Default");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
           
        }
    }


}
