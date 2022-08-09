using Microsoft.AspNetCore.Mvc;
using Shopping.DTO;
using Shopping.Services;
using System;

namespace Shopping.Controllers
{
    public class ShippingPriceController : Controller
    {
        private readonly IReposaitory<ShippingPriceDTO> services;

        public ShippingPriceController(IReposaitory<ShippingPriceDTO> services)
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
        public IActionResult Add(ShippingPriceDTO shipping)
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
        public IActionResult Edit(ShippingPriceDTO shipping,Guid id)
        {
            services.update(id, shipping);
            return RedirectToAction("Index");
        }
    }
}
