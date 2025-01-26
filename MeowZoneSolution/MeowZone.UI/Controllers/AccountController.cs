using MeowZone.Core.Domain.IdentityEntities;
using MeowZone.Core.DTO;
using MeowZone.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MeowZone.Controllers
{
	[Route("[controller]/[action]")]
	[AllowAnonymous]
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly RoleManager<ApplicationRole> _roleManager;

		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
			RoleManager<ApplicationRole> roleManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterDTO registerDTO)
		{

			//Check for validation errors
			if (ModelState.IsValid == false)
			{
				ViewBag.Errors = ModelState.Values.SelectMany(temp => temp.Errors).Select(temp => temp.ErrorMessage);
				return View(registerDTO);
			}

			ApplicationUser user = new ApplicationUser() { Email = registerDTO.Email, UserName = registerDTO.UserName };

			IdentityResult result = await _userManager.CreateAsync(user, registerDTO.Password);
			if (result.Succeeded)
			{
				if (registerDTO.UserType == Core.Enums.UserTypeOptions.Admin)
				{
					if (await _roleManager.FindByNameAsync(UserTypeOptions.Admin.ToString()) is null)
					{
						ApplicationRole applicationRole = new ApplicationRole()
							{ Name = UserTypeOptions.Admin.ToString() };
						await _roleManager.CreateAsync(applicationRole);
					}

					await _userManager.AddToRoleAsync(user, UserTypeOptions.Admin.ToString());
				}
				else
				{
					if (await _roleManager.FindByNameAsync(UserTypeOptions.User.ToString()) is null)
					{
						ApplicationRole applicationRole = new ApplicationRole()
							{ Name = UserTypeOptions.User.ToString() };
						await _roleManager.CreateAsync(applicationRole);
					}

					await _userManager.AddToRoleAsync(user, UserTypeOptions.User.ToString());
				}

				await _signInManager.SignInAsync(user, isPersistent: false);

				return RedirectToAction(nameof(HomeController.Index), "Home");
			}
			else
			{
				foreach (IdentityError error in result.Errors)
				{
					ModelState.AddModelError("Register", error.Description);
				}

				return View(registerDTO);
			}

		}

        [HttpGet]
        public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction(nameof(HomeController.Index), "Home");
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginDTO loginDto)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.Errors = ModelState.Values.SelectMany(temp => temp.Errors).Select(temp => temp.ErrorMessage);
				return View(loginDto);
			}

			var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);

			if (result.Succeeded)
			{
				//Admin
				ApplicationUser user = await _userManager.FindByEmailAsync(loginDto.UserName);
				if (user != null)
				{
					if (await _userManager.IsInRoleAsync(user, UserTypeOptions.Admin.ToString()))
					{
						return RedirectToAction("Index", "Home");
					}
				}

				return RedirectToAction(nameof(HomeController.Index), "Home");
			}

			ModelState.AddModelError("Login", "Invalid email or password");

			return View(loginDto);
		}
	}
}
