using Domain.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Business
{
   public interface IOpcionServices
    {
        public bool Save(Opcion o);

        public Opcion GetbyId(int id);

        public bool Delete(int id);

        public bool Update(Opcion o);

        public IEnumerable<Opcion> GetAll();

        public bool Exist(int id);
    }
}
