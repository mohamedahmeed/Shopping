using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shopping.DTO;
using Shopping.Models;
using Shopping.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Controllers
{
    [Authorize(Roles ="Admin")]
    public class PowerController : Controller
    {
        private readonly RoleManager<IdentityRole> role;
        private readonly IReposaitory<PowerDTO> services;
        private readonly UserManager<AppUser> manager;

        public PowerController(RoleManager<IdentityRole> role,IReposaitory<PowerDTO> services,UserManager<AppUser> manager)
        {
            this.role = role;
            this.services = services;
            this.manager = manager;
        }
        [AutoValidateAntiforgeryToken]
        public IActionResult Index()
        {
        List<PowerDTO> power=services.GetAll();
            return View(power);
        }
        public class UserDto
        {
            public string UserName { set; get; }
            public List<string> Roles { set; get; }
        }
        [Power(PermissionEnum.Add)]

        public async Task<IActionResult> Add()
        {
            
            var users = await manager.GetUsersInRoleAsync("Admin");
            ViewBag.user = users;
          var data=  typeof(PowerController).Assembly.GetTypes()
                .Where(c => c.IsClass && c.Name.Contains("Controller")).Select(c => new TempPropDto
            {
                Name = c.Name.Replace("Controller",""),

            });
            ViewBag.page = data;
            return View();
        }
       
        public class TempPropDto
        {
            public string Name { get; set; }
        }
        [HttpPost]
        public IActionResult Add(PowerDTO power)
        {
            services.insert(power);
            return RedirectToAction("index");
        }

        public  async Task<IActionResult> Edit(Guid id)
        {
            var users = await manager.GetUsersInRoleAsync("Admin");
            ViewBag.user = users;
            var data = typeof(PowerController).Assembly.GetTypes().Where(c => c.IsClass && c.Name.Contains("Controller")).Select(c => new TempPropDto
            {
                Name = c.Name.Replace("Controller", ""),

            });
            ViewBag.page = data;
            
            return View(services.GetById(id));
           
        }

        [HttpPost]
        public IActionResult Edit(Guid id,PowerDTO power)
        {
            services.update(id,power);
            return RedirectToAction("index");

        }
        public IActionResult Delete(Guid id)
        {
          PowerDTO p= services.GetById(id);
            services.Delete(id, p);
            return RedirectToAction("index");

        }

    }
}
