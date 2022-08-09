using Microsoft.AspNetCore.Mvc;
using Shopping.DTO;
using Shopping.Services;
using System;

namespace Shopping.Controllers
{
    public class ShippingTypesController : Controller
    {
        private readonly IReposaitory<ShippingTypesDTO> services;

        public ShippingTypesController(IReposaitory<ShippingTypesDTO> services)
        {
            this.services = services;
        }
        public IActionResult Index()
        {
            return View(services.GetAll());
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ShippingTypesDTO shipping)
        {
            services.insert(shipping);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            // services.GetById(id);
            return View(services.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(ShippingTypesDTO shipping, Guid id)
        {
            services.update(id, shipping);
            return RedirectToAction("Index");
        }
    }
}
