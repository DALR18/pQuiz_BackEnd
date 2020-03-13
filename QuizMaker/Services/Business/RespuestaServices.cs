using Dominio.Business;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Repositorio;
using Unity;

namespace Services.Business
{
    class RespuestaServices : IRespuestaServices
    {


        #region Field
        [Dependency]
        public IRespuestaServices RespuestaRepository { get; set; }
        #endregion Field


        public bool Delete(int id)
        {
            return RespuestaRepository.Delete(id);
        }

      

        public bool Exist(string valor)
        {
            return RespuestaRepository.Exist(valor);
        }

        public IEnumerable<Respuesta> GetAll()
        {
            return RespuestaRepository.GetAll();
        }

        public Respuesta GetbyId(int id)
        {
            return RespuestaRepository.GetbyId(id);
        }

        public bool Save(Respuesta c)
        {
            return RespuestaRepository.Save(c);
        }

        public bool Update(Respuesta c)
        {
            return RespuestaRepository.Update(c);
        }
    }
}
