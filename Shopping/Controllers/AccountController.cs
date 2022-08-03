using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shopping.DTO;
using Shopping.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Shopping.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> role;
        private readonly UserManager<AppUser> manager;
        private readonly SignInManager<AppUser> signIn;
        private readonly IMapper mapper;

        public AccountController(RoleManager<IdentityRole> role,UserManager<AppUser> manager,SignInManager<AppUser> signIn,IMapper mapper)
        {
            this.role = role;
            this.manager = manager;
            this.signIn = signIn;
            this.mapper = mapper;
        }
        public IActionResult Register() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO user)
        {
        //  await  manager.GetUsersInRoleAsync("");
            if (ModelState.IsValid)
            {
                AppUser identity = mapper.Map<AppUser>(user);
                IdentityResult result = await manager.CreateAsync(identity,identity.PasswordHash);
                if (result.Succeeded)
                {
                    await signIn.SignInAsync(identity,false);
                    return RedirectToAction("Index", "Power");

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
          
            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO user)
        {
            if (ModelState.IsValid)
            {
                AppUser result =  await manager.FindByNameAsync(user.UserName);
                if (result != null)
                {
                    SignInResult R = 
                        await signIn.PasswordSignInAsync(result, user.Password, user.ispresist, false);
                    if (R.Succeeded)
                    {
                        return RedirectToAction("Index", "Order");
                    }
                    else
                    {
                        ModelState.AddModelError("", "User Name Or Password is Invalid");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User Name Or Password is Invalid");
                }
            }
            return View(user);
        }
        public async Task<IActionResult> LogOut()
        {
            await signIn.SignOutAsync();
            return RedirectToAction("Login");
        }
      [Authorize(Roles = "Admin")]

        public  IActionResult AddAdmin()
        {
            // List<AppUser> user = await manager.GetUserNameAsync()
        var users=  manager.Users;
         var roles= role.Roles;
            ViewBag.role = roles;
            ViewBag.user = users;
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddAdmin(string UserName,string RoleName)
        {
            //  await  manager.GetUsersInRoleAsync("");
            if (ModelState.IsValid)
            {
               // AppUser identity = mapper.Map<AppUser>(user);
               AppUser name= await  manager.FindByNameAsync(UserName);
               // IdentityResult result = await manager.CreateAsync(identity, identity.PasswordHash);
                if (name !=null)
                {
                    await manager.AddToRoleAsync(name, RoleName);
                   // await signIn.SignInAsync(identity, false);
                   // return RedirectToAction("Index", "Power");

                }
               
            }

            return RedirectToAction("Index", "Power");
        }
    }

}
