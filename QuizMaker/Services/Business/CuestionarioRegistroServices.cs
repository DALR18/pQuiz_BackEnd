
using Data.Repositories;
using Domain.Business;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace Services.Business
{
    public class CuestionarioRegistroServices : ICuestionarioRegistroServices
    {

        #region FIELDS
        [Dependency]
        public ICuestionarioRegistroRepository cuestionarioregistro { get; set; }
        #endregion FIELDS

        public bool Delete(int id)
        {
            return cuestionarioregistro.Delete(id);
        }

        public bool Exist(int id)
        {
            return cuestionarioregistro.Exist(id);
        }

        public IEnumerable<CuestionarioRegistro> GetAll()
        {
            return cuestionarioregistro.GetAll();
        }

        public CuestionarioRegistro GetbyId(int id)
        {
            return cuestionarioregistro.GetbyId(id);
        }

        public bool save(CuestionarioRegistro c)
        {
            return cuestionarioregistro.save(c);
        }

        public bool Update(CuestionarioRegistro c)
        {
            return cuestionarioregistro.Update(c);
        }
    }
}
