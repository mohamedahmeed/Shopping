using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping.DTO;
using Shopping.Models;
using Shopping.Services;
using System;
using System.Collections.Generic;

namespace Shopping.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GovernmentController : Controller
    {
        private readonly IReposaitory<GovernmentDTO> services;

        public GovernmentController(IReposaitory<GovernmentDTO> services)
        {
            this.services = services;
        }
        [Power(PermissionEnum.Show)]

        public IActionResult Index()
        {
          List<GovernmentDTO> governments= services.GetAll();
            return View(governments);
        }
        [Power(PermissionEnum.Add)]

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(GovernmentDTO government)
        {
            if (ModelState.IsValid)
            {
                services.insert(government);
                return RedirectToAction("index");
            }
            else return View(government);
            
        }
        [Power(PermissionEnum.Edit)]
        public IActionResult Edit(Guid id)
        {
          GovernmentDTO government=  services.GetById(id);
            return View(government);
        }

        [HttpPost]
        public IActionResult Edit(Guid id,GovernmentDTO government)
        {
            if (ModelState.IsValid)
            {
                services.update(id, government);
                return RedirectToAction("index");
            }
            else return View(government);
          
        }
    }
}
