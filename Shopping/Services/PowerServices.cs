using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopping.DTO;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping.Services
{
    public class PowerServices : IReposaitory<PowerDTO>
    {
        private readonly Shipping dp;
        private readonly IMapper mapper;

        public PowerServices(Shipping dp, IMapper mapper)
        {
            this.dp = dp;
            this.mapper = mapper;
        }


        public List<PowerDTO> GetAll()
        {
            List<Powers> powers = dp.powers.Include(s => s.user).ToList();
            return mapper.Map<List<PowerDTO>>(powers);
        }

        public PowerDTO GetById(Guid id)
        {
            Powers power = dp.powers.Include(s => s.user).FirstOrDefault(x => x.powerId == id);
            return mapper.Map<PowerDTO>(power);
        }

        public List<PowerDTO> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public void insert(PowerDTO obj)
        {
            Powers power = mapper.Map<Powers>(obj);
            dp.powers.Add(power);
            dp.SaveChanges();
        }

        public void update(Guid id, PowerDTO obj)
        {
           
            Powers power = mapper.Map<Powers>(obj);
            dp.Update(power);
            dp.SaveChanges();
        }

        public bool HasPermission(PermissionEnum permission, string page, string id)
        {
            page = page.ToLower();
            var ent = dp.powers.Where(v => v.webSiteUserID == id && v.pageName.ToLower() == page);
            switch (permission)
            {
                case PermissionEnum.Add:
                    ent = ent.Where(c => c.canAdd);
                    break;
                case PermissionEnum.Show:
                    ent = ent.Where(c => c.canSee);
                    break;
                case PermissionEnum.Edit:
                    ent = ent.Where(c => c.canUpdate);
                    break;
                case PermissionEnum.Delete:
                    ent = ent.Where(c => c.canDelete);
                    break;
            }
            return ent.Any();
        }

        public void Delete(Guid id, PowerDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
