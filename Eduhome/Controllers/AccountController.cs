using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.ViewModels;
using DAL.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Utilities.Helpers.Enums;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Eduhome.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController( UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }



        [HttpGet(nameof(Register))]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM); 
            }

            AppUser appUser = new();

            appUser.FirstName = registerVM.FirstName;
            appUser.LastName = registerVM.LastName;
            appUser.Email = registerVM.Email;
            appUser.UserName = registerVM.Username;


            var result = await _userManager.CreateAsync(appUser, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(registerVM);
            }


            var roleResult = await _userManager.AddToRoleAsync(appUser, Roles.Member.ToString());
            if (!roleResult.Succeeded)
            {
                foreach (var item in roleResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(registerVM);

            }

            return Json(appUser);
            return View();
        }

        //public async Task CreateRoles()
        //{
        //    foreach (var item in Enum.GetValues(typeof(Roles)))
        //    {
        //        if (!await _roleManager.RoleExistsAsync(item.ToString()))
        //        {
        //            await _roleManager.CreateAsync(new IdentityRole(item.ToString()));
        //        }
        //    }

        //}
    }
}

