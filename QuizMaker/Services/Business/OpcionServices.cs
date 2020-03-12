using Data.Repositories;
using Domain.Business;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace Services.Business
{
    public class OpcionServices : IOpcionServices
    {
        #region FIELDS
        [Dependency]
        public IOpcionRepository opcion { get; set; }
        #endregion FIELDS
        public bool Delete(int id)
        {
            return opcion.Delete(id);
        }

        public bool Exist(int id)
        {
            return opcion.Exist(id);
        }

        public IEnumerable<Opcion> GetAll()
        {
            return opcion.GetAll();
        }

        public Opcion GetbyId(int id)
        {
            return opcion.GetbyId(id);
        }

        public bool Save(Opcion o)
        {
            return opcion.save(o);
        }

        public bool Update(Opcion o)
        {
            return opcion.Update(o);
        }
    }
}
