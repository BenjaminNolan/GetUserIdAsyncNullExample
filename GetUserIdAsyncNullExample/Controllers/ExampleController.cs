using System;
using System.Threading.Tasks;
using GetUserIdAsyncNullExample.Data;
using GetUserIdAsyncNullExample.Models;
using GetUserIdAsyncNullExample.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GetUserIdAsyncNullExample.Controllers
{
    [AllowAnonymous]
    public class ExampleController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ExampleContext _context;
        private readonly IHostingEnvironment _env;

        public ExampleController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor,
            ExampleContext context,
            IHostingEnvironment env
        ) {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _env = env;
        }

        [Route("/", Name = "Home")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [Route("register", Name = "Register")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Register(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;

            return View(new RegisterViewModel());
        }

        [Route("register", Name = "Register")]
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid) {
                var user = new User {
                    UserName = model.Email,
                    Email = model.Email,
                    DisplayName = model.DisplayName,
                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded) {
                    string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    return RedirectToAction("Success");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("success", Name = "Register/Success")]
        public IActionResult Success()
        {
            return View();
        }

        [NonAction]
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors) {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        [NonAction]
        private void AddError(string error)
        {
            ModelState.AddModelError(string.Empty, error);
        }
    }
}
