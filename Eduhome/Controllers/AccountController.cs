using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Business.ViewModels;
using DAL.Identity;
using Microsoft.AspNetCore.Authorization;
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
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController( UserManager<AppUser> userManager,
                                  RoleManager<IdentityRole> roleManager,
                                  SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }



        [HttpGet(nameof(Register))]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", controllerName: "Home");
            }
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


            var roleResult = await _userManager.AddToRoleAsync(appUser, Roles.SuperAdmin.ToString());
            if (!roleResult.Succeeded)
            {
                foreach (var item in roleResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(registerVM);

            }

            return RedirectToAction("Index", controllerName: "Home"); 
        }

        [HttpGet(nameof(Login))]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost(nameof(Login))]
        public async Task<IActionResult>  Login(LoginVM loginVM)
        {

            if (User.Identity.IsAuthenticated)
            {
               return RedirectToAction("Index", controllerName: "Home");
            }

            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            AppUser appUser =await _userManager.FindByNameAsync(loginVM.Username);

            if (appUser is null)
            {
                ModelState.AddModelError("", "User Not Found!");
                return View(loginVM);
            }

            var result = await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, loginVM.RememberMe, true);

            if (!result.Succeeded)

            {
                ModelState.AddModelError("","Invalid Password");
                return View(loginVM);
            }

            if (result.IsNotAllowed)
            {
                ModelState.AddModelError("", "Please Confirm Your Account");
                return View();
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Your Account has been locked!");
                return View();
            }

            if (await _userManager.IsInRoleAsync(appUser, Roles.Admin.ToString()))
            {
                return RedirectToAction("Index", controllerName: "Dashboard", new { area  = "Admin" });
            }
            
            return RedirectToAction("Index", controllerName: "Home");
        }

        [HttpGet(nameof(Logout))]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                 await  _signInManager.SignOutAsync();
            }

            return RedirectToAction("Index", controllerName: "Home");
        }

        
        [Authorize(Roles= "SuperAdmin")]
        public async Task CreateRoles()
        {
            foreach (var item in Enum.GetValues(typeof(Roles)))
            {
                if (!await _roleManager.RoleExistsAsync(item.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole(item.ToString()));
                }
            }

        }

        public async Task<IActionResult> EmailConfirmation(AppUser appUser)
        {
            string token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);

            string redirectionLink = Url.Action(nameof(ConfirmEmail), controller: "Account", new
            {
                username = appUser.UserName,
                token
            }, protocol: HttpContext.Request.Scheme);

            string linkTag = $"<a href=\"{redirectionLink}\"></a>";
            await SendEmail(linkTag);

            return Json("Confirimation Link is Sent.Please Check Your Email Inbox.");
        }


        public async Task<IActionResult> ConfirmEmail(string userName,string token)
        {
            AppUser user = await _userManager.FindByNameAsync(userName);
     
            await _userManager.ConfirmEmailAsync(user, token);

            await _signInManager.SignInAsync(user, true);

            return RedirectToAction("Index", "Home");


        }

        public async Task<IActionResult> SendEmail(string routeLink)
        {
            string from = "arif.babayev.2005@gmail.com";
            string to = "farid.mammadov@code.edu.az";
            string subject = "This message send via Subscribe button on Eduhome";
            string body = routeLink;

            MailMessage message = new(from, to, subject, body);

            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;

            NetworkCredential credential = new(from, "bcxcejzxkazgrpri");

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

            client.UseDefaultCredentials = false;

            client.EnableSsl = true;

            client.Credentials = credential;

            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            try
            {
                await client.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json("Done");

        }
    }
}

