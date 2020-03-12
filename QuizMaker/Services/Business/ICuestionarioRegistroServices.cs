using Domain.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Business
{
    public interface ICuestionarioRegistroServices
    {
        public bool save(CuestionarioRegistro c);

        public CuestionarioRegistro GetbyId(int id);

        public bool Delete(int id);

        public bool Update(CuestionarioRegistro c);

        public IEnumerable<CuestionarioRegistro> GetAll();

        public bool Exist(int id);
    }
}
