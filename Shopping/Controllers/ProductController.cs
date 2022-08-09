using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shopping.DTO;
using Shopping.Models;
using Shopping.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace Shopping.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductServices s;
        private readonly IReposaitory<ProductDTO> services;

        public ProductController(ProductServices s,IReposaitory<ProductDTO> services)
        {
            this.s = s;
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
        public IActionResult Add(OrderDTO orderDTo)
        {
            //var orderDTo = new OrderDTO();

            var order = new Order()
            {
                Id=orderDTo.Id,
                clientphone1=orderDTo.clientphone1
                
            };
            var productss = new List<Product>();
            productss = orderDTo.Products;
            



           
         //   s.insert(products);
            return RedirectToAction("Index");
        }
        //public IActionResult Edit(Guid id)
        //{
           
        //    return View(services.GetById(id));
        //}
        //[HttpPost]
        //public IActionResult Edit(ProductDTO product, Guid id)
        //{
        //    services.update(id, product);
        //    return RedirectToAction("Index");
        //}
    }
}
