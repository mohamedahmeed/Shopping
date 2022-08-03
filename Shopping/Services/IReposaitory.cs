using System;
using System.Collections.Generic;

namespace Shopping.Services
{
    public interface IReposaitory<t>
    {
        public List<t> GetAll();
        public t GetById(Guid id);
        public List<t> GetByName(string name);
        public void insert(t obj);
        public void update(Guid id,t obj);
        public void Delete(Guid id, t obj);



    }
}
