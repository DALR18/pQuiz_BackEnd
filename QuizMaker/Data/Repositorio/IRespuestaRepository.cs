using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Business;

namespace Data.Repositorio
{
   public interface IRespuestaRepository
    {
        public bool Save(Respuesta c);

        public Respuesta GetbyId(int id);

        public bool Delete(int id);

        public bool Update(Respuesta c);

        public IEnumerable<Respuesta> GetAll();

        public bool Exist(int id);
    }
}
