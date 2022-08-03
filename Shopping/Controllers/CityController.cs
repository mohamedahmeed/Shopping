using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping.DTO;
using Shopping.Models;
using Shopping.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CityController : Controller
    {
        private readonly IReposaitoryCity<CityDTO> services;
        private readonly IReposaitory<GovernmentDTO> s;

        public CityController(IReposaitoryCity<CityDTO> services, IReposaitory<GovernmentDTO> s)
        {
            this.services = services;
            this.s = s;
        }
        [Power(PermissionEnum.Show)]
        public IActionResult Index()
        {
          List<CityDTO> city = services.GetAll();
            return View(city);
        }
        [HttpPost,AllowAnonymous]
        public IActionResult GetCity(Guid id)
        {
            List<CityDTO> city = services.GetCityById(id);
            return Json(city);
        }
        [Power(PermissionEnum.Add)]
        public IActionResult Add()
        {
            List<GovernmentDTO> governments = s.GetAll();
            ViewBag.govern = governments;
            return View();
        }
        [HttpPost]
        public IActionResult Add(CityDTO city)
        {
            services.insert(city);
            return RedirectToAction("Index");
        }

        [Power(PermissionEnum.Edit)]

        public IActionResult Edit(Guid id)
        {
           CityDTO city=services.GetById(id);
            List<GovernmentDTO> governments = s.GetAll();
            ViewBag.govern = governments;
            return View(city);

        }

        [HttpPost]
        public  IActionResult Edit(Guid id,CityDTO city)
        { 
            services.update(id, city);
            return RedirectToAction("Index");

        }
    }
}
