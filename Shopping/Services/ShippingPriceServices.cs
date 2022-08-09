using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopping.DTO;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping.Services
{
    public class ShippingPriceServices : IReposaitory<ShippingPriceDTO>
    {
        private readonly Shipping dp;
        private readonly IMapper mapper;

        public ShippingPriceServices(Shipping dp, IMapper mapper)
        {
            this.dp = dp;
            this.mapper = mapper;
        }

        public void Delete(Guid id, ShippingPriceDTO obj)
        {
            throw new NotImplementedException();
        }

        public List<ShippingPriceDTO> GetAll()
        {
            List<ShippingPrice> shippingPrices = dp.ShippingPrices.ToList();

            return mapper.Map<List<ShippingPriceDTO>>(shippingPrices);
        }

        public ShippingPriceDTO GetById(Guid id)
        {
           ShippingPrice shippingPrice=dp.ShippingPrices.FirstOrDefault(x => x.Id == id);
            return mapper.Map<ShippingPriceDTO>(shippingPrice);
        }

        public List<ShippingPriceDTO> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void insert(ShippingPriceDTO obj)
        {
         ShippingPrice shippingPrice=  mapper.Map<ShippingPrice>(obj);
            dp.Add(shippingPrice);
            dp.SaveChanges();
        }

        public void update(Guid id, ShippingPriceDTO obj)
        {
            ShippingPrice shippingPrice = mapper.Map<ShippingPrice>(obj);
            dp.Update(shippingPrice);
            dp.SaveChanges();

        }
    }
}
