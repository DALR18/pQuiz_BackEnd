using Dominio.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Business
{
   public interface ICuestionarioServices
    {
        public bool Save(Cuestionario c);

        public Cuestionario GetbyId(int id);

        public bool Delete(int id);

        public bool Update(Cuestionario c);

        public IEnumerable<Cuestionario> GetAll();

        public bool Exist(string valor);
    }
}
