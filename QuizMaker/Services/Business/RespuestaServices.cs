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
            RespuestaRepository.Delete(id);
        }

        public bool Exist(int id)
        {
            RespuestaRepository.Exist(id);
        }

        public IEnumerable<Respuesta> GetAll()
        {
            RespuestaRepository.GetAll();
        }

        public Respuesta GetbyId(int id)
        {
            RespuestaRepository.GetbyId(id)
        }

        public bool Save(Respuesta c)
        {
            throw new NotImplementedException();
        }

        public bool Update(Respuesta c)
        {
            throw new NotImplementedException();
        }
    }
}
