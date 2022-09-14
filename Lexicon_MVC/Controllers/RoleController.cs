using Lexicon_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lexicon_MVC.Controllers
{
	[Authorize(Roles = "Admin")]
	public class RoleController : Controller
	{
		readonly RoleManager<IdentityRole> _roleManager;
		readonly UserManager<ApplicationUser> _userManager;

		public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			return View(_roleManager.Roles);
		}
	}
}
