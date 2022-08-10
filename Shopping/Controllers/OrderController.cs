using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shopping.DTO;
using Shopping.Models;
using Shopping.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace Shopping.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IReposaitory<ShippingTypesDTO> shipping;
        private readonly OrderServices orderServices;
        private readonly IMapper mapper;
        private readonly IReposaitory<GovernmentDTO> gover;
        private readonly IReposaitory<OrderDTO> servies;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        private readonly Shipping dp;

        public OrderController(Shipping dp  ,IReposaitory<ShippingTypesDTO> shipping,OrderServices orderServices,IMapper mapper,IReposaitory<GovernmentDTO> gover, IReposaitory<OrderDTO> servies,UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.shipping = shipping;
            this.orderServices = orderServices;
            this.mapper = mapper;
            this.gover = gover;
            this.servies = servies;
            _userManager = userManager;
            _signInManager = signInManager;
            this.dp = dp;
            
        }
        [Power(PermissionEnum.Show)]
        public async Task<IActionResult> Index()
        {

            string name=User.Identity.Name;
            List<OrderDTO> orders ;
          var UUser= await  _userManager.FindByNameAsync(name);
            var Isadmin = await _userManager.IsInRoleAsync(UUser, "admin");
            if (Isadmin)
            {
                 orders = servies.GetAll();
            }
            else
            {
                 orders = servies.GetByName(name);
            }
            return View(orders);
        }
        [Power(PermissionEnum.Show)]

        public IActionResult Details(Guid id)
        {
           return View(servies.GetById(id));
        }
        [Power(PermissionEnum.Add)]

        public IActionResult Add()
        
        {
            var government= gover.GetAll();
            ViewBag.gov = government;

            var shippingType = shipping.GetAll();
            ViewBag.ship= shippingType;

            return View();
        }
        [HttpPost]
        public IActionResult Add(OrderDTO order)
        {
            order.clientName = User.Identity.Name;
            order.States = Enums.states.Pending;
            var shippingprice = dp.ShippingTypes.Where(x => x.Id == order.ShippingTypesId).Select(x => x.price).FirstOrDefault();
            var cityPrice = dp.cities.Where(x => x.Id == order.cityId).Select(x => x.price).FirstOrDefault();
            var weightPrice = 0;
            var ShippingPrices = dp.ShippingPrices.FirstOrDefault();
            //var ShipingType = dp.ShippingTypes.FirstOrDefault();
            var weight =order.Products.Sum(x => (x.ProductWeight)*(x.Amount));
            if(weight > ShippingPrices.ToWeight)
            {
                var incrasingweight = weight-ShippingPrices.ToWeight;
                weightPrice = (incrasingweight * ShippingPrices.extraPrice) + ShippingPrices.Price;
            }

            else
            {
                weightPrice = ShippingPrices.Price;
            }
           var Price = (decimal)shippingprice + (decimal)cityPrice + weightPrice ;
            order.price = Price;
            servies.insert(order);
            return RedirectToAction("Index");   
        }
        [Power(PermissionEnum.Edit)]
        public IActionResult Edit(Guid id)
        {
            var government = gover.GetAll();
            ViewBag.gov = government;

            var shippingType = shipping.GetAll();
            ViewBag.ship = shippingType;
            return View(servies.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Guid id,OrderDTO order)
        {
            order.clientName = User.Identity.Name;
            order.States = Enums.states.Pending;
            var shippingprice = dp.ShippingTypes.Where(x => x.Id == order.ShippingTypesId).Select(x => x.price).FirstOrDefault();
            var cityPrice = dp.cities.Where(x => x.Id == order.cityId).Select(x => x.price).FirstOrDefault();
            var weightPrice = 0;
            var ShippingPrices = dp.ShippingPrices.FirstOrDefault();
            //var ShipingType = dp.ShippingTypes.FirstOrDefault();
            var weight = order.Products.Sum(x => (x.ProductWeight) * (x.Amount));
            if (weight > ShippingPrices.ToWeight)
            {
                var incrasingweight = weight - ShippingPrices.ToWeight;
                weightPrice = (incrasingweight * ShippingPrices.extraPrice) + ShippingPrices.Price;
            }

            else
            {
                weightPrice = ShippingPrices.Price;
            }
            var Price = (decimal)shippingprice + (decimal)cityPrice + weightPrice;
            order.price = Price;
            servies.update(id, order);
            return RedirectToAction("Index");
        }
        
        public IActionResult Approve(Guid id)
        {
            orderServices.Approved(id);
            return RedirectToAction("Index");

        }
        public IActionResult Regicted(Guid id)
        {
            orderServices.Regicted(id);
            return RedirectToAction("Index");

        }
    }
}
