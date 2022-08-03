using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopping.DTO;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;

namespace Shopping.Services
{
    public class GovernmentServices : IReposaitory<GovernmentDTO>
    {
        private readonly Shipping dp;
        private readonly IMapper mapper;
        public GovernmentServices(Shipping dp , IMapper mapper)
        {
            this.dp = dp;
            this.mapper = mapper;
        }

        public void Delete(Guid id, GovernmentDTO obj)
        {
            Government power = mapper.Map<Government>(obj);
            dp.Remove(power);
            dp.SaveChanges();
        }

        public List<GovernmentDTO> GetAll()
        {
            List<Government> governments = dp.governments.Include(s=>s.cities).ToList();

            return mapper.Map<List<GovernmentDTO>>(governments);
        }

        public GovernmentDTO GetById(Guid id)
        {
            Government g = dp.governments.Include(s => s.cities).FirstOrDefault(s=>s.Id==id);
            return mapper.Map<GovernmentDTO>(g);
        }

        public List<GovernmentDTO> GetByName(string name)
        {
            Government g = dp.governments.FirstOrDefault(s => s.Name == name);
            return mapper.Map<List<GovernmentDTO>>(g);
        }

        public void insert(GovernmentDTO obj)
        {
            Government government = mapper.Map<Government>(obj);
            dp.governments.Add(government);
            dp.SaveChanges();
        }

        public void update(Guid id, GovernmentDTO obj)
        {
            Government g = mapper.Map<Government>(obj);
            dp.Update(g);
            dp.SaveChanges();
        }
    }
}
