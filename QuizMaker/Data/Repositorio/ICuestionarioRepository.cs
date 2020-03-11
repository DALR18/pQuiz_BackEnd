using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Business;


namespace Data.Repositorio
{
    interface ICuestionarioRepository
    {
        public bool Save(Cuestionario b);

        public Cuestionario GetbyId(int id);

        public bool Delete(int id);

        public bool Update(Cuestionario b);

        public IEnumerable<Cuestionario> GetAll();

        public bool Exist(int id);
    }
}
