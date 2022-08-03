using System;
using System.Collections.Generic;

namespace Shopping.Services
{
    public interface IReposaitoryCity<t>
    {
        public List<t> GetAll();
        public t GetById(Guid id);
        public List<t> GetCityById(Guid id);
        public void insert(t obj);
        public void update(Guid id, t obj);
    }
}
