using Dominio.Business;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Repositorio;
using Unity;

namespace Services.Business
{
   public class CuestionarioServices : ICuestionarioServices
    {

        #region Field
        [Dependency]
        public ICuestionarioServices CuestionarioRepository { get; set; }
        #endregion Field


        public bool Delete(int id)
        {
           return  CuestionarioRepository.Delete(id);
        }

        public bool Exist(string valor)
        {
            return CuestionarioRepository.Exist(valor);
        }

        public IEnumerable<Cuestionario> GetAll()
        {
            return CuestionarioRepository.GetAll();
        }

        public Cuestionario GetbyId(int id)
        {
            return CuestionarioRepository.GetbyId(id);
        }

        public bool Save(Cuestionario c)
        {
            return CuestionarioRepository.Save(c);
        }

        public bool Update(Cuestionario c)
        {
            return CuestionarioRepository.Update(c);
        }
    }
}
