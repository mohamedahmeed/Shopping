using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopping.DTO;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping.Services
{
    public class ProductServices : IReposaitory<ProductDTO>
    {
        private readonly Shipping dp;
        private readonly IMapper mapper;

        public ProductServices(Shipping dp, IMapper mapper)
        {
            this.dp = dp;
            this.mapper = mapper;
        }
        public void Delete(Guid id, ProductDTO obj)
        {
            throw new NotImplementedException();
        }

        public List<ProductDTO> GetAll()
        {
            List<Product> products = dp.products.Include(s => s.Order).ToList();
            return mapper.Map<List<ProductDTO>>(products);
        }

        public ProductDTO GetById(Guid id)
        {
           Product product=dp.products.Include(s=>s.Order).FirstOrDefault(s=> s.Id == id);
            return mapper.Map<ProductDTO>(product);
        }

        public List<ProductDTO> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void insert(ProductDTO obj)
        {
          Product product=  mapper.Map<Product>(obj);
            dp.Add(product);
            dp.SaveChanges();
        }
        public void insert(List<ProductDTO> obj)
        {
            var products = new  List<Product>();
            foreach (var item in obj)
            {
             Product p= mapper.Map<Product>(item);
                products.Add(p);
            }
            dp.AddRange(products);
            dp.SaveChanges();
        }
        public void update(Guid id, ProductDTO obj)
        {
            Product product = mapper.Map<Product>(obj);
            dp.Update(product);
            dp.SaveChanges();
        }
    }
}
