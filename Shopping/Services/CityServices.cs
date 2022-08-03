using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopping.DTO;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping.Services
{
    public class CityServices : IReposaitoryCity<CityDTO>
    {
        private readonly Shipping dp;
        private readonly IMapper mapper;

        public CityServices(Shipping dp,IMapper mapper)
        {
            this.dp = dp;
            this.mapper = mapper;
        }
        public List<CityDTO> GetAll()
        {
           List<City> city = dp.cities.Include(s=>s.government).ToList();
          return mapper.Map<List<CityDTO>>(city);
        }

        public CityDTO GetById(Guid id)
        {
           City city=dp.cities.Include(s=>s.government).SingleOrDefault(s=>s.Id==id);
            return mapper.Map<CityDTO>(city);
        }

        public List<CityDTO> GetByName(string name)
        {
            City city = dp.cities.Include(s => s.government).SingleOrDefault(s => s.cityName == name);
            return mapper.Map<List<CityDTO>>(city);
            throw new System.NotImplementedException();

        }

        public List<CityDTO> GetCityById(Guid id)
        {
            List<City> cities = dp.cities.Where(s=>s.governmentId==id).ToList();
            return mapper.Map<List<CityDTO>>(cities);
            
        }

        public void insert(CityDTO obj)
        {
           City city =mapper.Map<City>(obj);
            dp.cities.Add(city);
            dp.SaveChanges();
        }

        public  void update(Guid id, CityDTO obj)
        {
            City c=mapper.Map<City>(obj);
            dp.Update(c);
            dp.SaveChanges();
        }
    }
}
