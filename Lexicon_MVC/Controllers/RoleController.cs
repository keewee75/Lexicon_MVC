using Lexicon_MVC.Models;
using Lexicon_MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create (IdentityRole role) // Här behövs async, Task och await
		{
			role.NormalizedName = role.Name.ToUpper();
			await _roleManager.CreateAsync(role);

			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Delete (string id)
		{
			IdentityRole role = await _roleManager.FindByIdAsync(id); // Hitta rätt roll med id
			await _roleManager.DeleteAsync(role);
			return RedirectToAction("Index");
		}

		public IActionResult AddUserToRole()
		{
			ViewBag.Users = new SelectList(_userManager.Users, "Id", "UserName"); // Visa lista med Users
			ViewBag.Roles = new SelectList(_roleManager.Roles, "Name", "Name"); // Visa lista med Roles

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddUserToRole(string userId, string roleName)
		{
			var user = await _userManager.FindByIdAsync(userId);
			await _userManager.AddToRoleAsync(user, roleName);

			return RedirectToAction("Index");
		}

		public IActionResult ShowAllUsers()
		{
			return View(_userManager.Users);
		}

		public async Task<IActionResult> ShowUserRoles(string Id)
		{
			UserRoleViewModel vm = new UserRoleViewModel();
			var user = await _userManager.FindByIdAsync(Id);

			var assignedRoles = new List<string>(await _userManager.GetRolesAsync(user));
			vm.UserId = Id;
			vm.UserName = user.UserName;

			vm.Roles.AddRange(assignedRoles);

			return View(vm);
		}

		public async Task<IActionResult> RemoveRoleFromUser(string rolename, string userid)
		{
			var user = await _userManager.FindByIdAsync(userid);
			await _userManager.RemoveFromRoleAsync(user, rolename);

			return RedirectToAction("ShowUserRoles", new { id = userid });
		}
	}
}
