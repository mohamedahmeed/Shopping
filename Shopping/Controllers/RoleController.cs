using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shopping.DTO;
using Shopping.Models;
using System.Threading.Tasks;

namespace Shopping.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly UserManager<AppUser> user;
        private readonly RoleManager<IdentityRole> identity;
        private readonly IMapper mapper;

        public RoleController(UserManager<AppUser> user,RoleManager<IdentityRole> identity,IMapper mapper)
        {
            this.user = user;
            this.identity = identity;
            this.mapper = mapper;
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add( RoleDTO role)
        {
            IdentityRole app=mapper.Map<IdentityRole>(role);
       IdentityResult result=await identity.CreateAsync(app);
            if (result.Succeeded)
            {
                return View();
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                
            }
            return View();
        }

        //public IActionResult Claims()
        //{
            
        //}
    }
}
