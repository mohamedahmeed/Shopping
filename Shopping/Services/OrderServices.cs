using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopping.DTO;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping.Services
{
    public class OrderServices : IReposaitory<OrderDTO>
    {
        private readonly IMapper mapper;
        private readonly Shipping dp;

        public OrderServices(IMapper mapper,Shipping dp)
        {
            this.mapper = mapper;
            this.dp = dp;
        }
        public List<OrderDTO> GetAll()
        {
            List<Order> orders = dp.Order.Include(s=>s.city).ToList();
          List<OrderDTO> order= mapper.Map<List<OrderDTO>>(orders);
            return order;
        }

        public OrderDTO GetById(Guid id)
        {
           Order order=dp.Order.Include(s => s.city).Include(s=>s.Products).FirstOrDefault(o=>o.Id==id);
            OrderDTO o=mapper.Map<OrderDTO>(order);
            return o;
        }

        public List<OrderDTO> GetByName(string name)
        {
            //Order order = dp.Order.FirstOrDefault(o => o.clientName==name);
            //OrderDTO o = mapper.Map<OrderDTO>(order);
            //return o;
           List<Order> order = dp.Order.Include(c=>c.city).Where(o => o.clientName == name).ToList();
            List<OrderDTO> or = mapper.Map<List<OrderDTO>>(order);
            return or;
        }

        public void insert(OrderDTO obj)
        {
          Order order=mapper.Map<Order>(obj);
            dp.Order.Add(order);
            dp.SaveChanges();
        }

        public void update(Guid id, OrderDTO obj)
        {
            Order order = mapper.Map<Order>(obj);
            dp.Update(order);
            dp.SaveChanges();
        }


        public void Approved(Guid id)
        {
            Order order = dp.Order.Include(s => s.city).FirstOrDefault(o => o.Id == id);
            order.States = Enums.states.approved;
            dp.Update(order);
            dp.SaveChanges();

        }
        public void Regicted(Guid id)
        {
            Order order = dp.Order.Include(s => s.city).FirstOrDefault(o => o.Id == id);
            order.States = Enums.states.Regicted;
            dp.Update(order);
            dp.SaveChanges();

        }

        public void Delete(Guid id, OrderDTO obj)
        {
            Order power = mapper.Map<Order>(obj);
            dp.Remove(power);
            dp.SaveChanges();
        }
    }
}
