using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopping.DTO;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping.Services
{
    public class ShippingTypesServices : IReposaitory<ShippingTypesDTO>
    {
        private readonly Shipping dp;
        private readonly IMapper mapper;

        public ShippingTypesServices(Shipping dp, IMapper mapper)
        {
            this.dp = dp;
            this.mapper = mapper;
        }

        public void Delete(Guid id, ShippingTypesDTO obj)
        {
            throw new NotImplementedException();
        }

        public List<ShippingTypesDTO> GetAll()
        {
            List<ShippingTypes> shippingTypes = dp.ShippingTypes.Include(s => s.Order).ToList();
            return mapper.Map<List<ShippingTypesDTO>>(shippingTypes);
        }

        public ShippingTypesDTO GetById(Guid id)
        {
           ShippingTypes shippingTypes=dp.ShippingTypes.Include(s=>s.Order).FirstOrDefault(s => s.Id == id);
            return mapper.Map<ShippingTypesDTO>(shippingTypes);
        }

        public List<ShippingTypesDTO> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void insert(ShippingTypesDTO obj)
        {
          ShippingTypes shippingTypes=  mapper.Map<ShippingTypes>(obj);
            dp.Add(shippingTypes);
            dp.SaveChanges();
        }

        public void update(Guid id, ShippingTypesDTO obj)
        {
            ShippingTypes shippingTypes = mapper.Map<ShippingTypes>(obj);
            dp.Update(shippingTypes);
            dp.SaveChanges();
        }
    }
}
