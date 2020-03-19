using System;
using System.Collections.Generic;
using System.Text;
using Domain.Bussines;

namespace Services.Bussines
{
    public interface IUsuarioServices
    {
        public bool save(Usuario u);

        public Usuario GetbyId(int id);

        public bool Delete(int id);

        public bool Update(Usuario u);

        public IEnumerable<Usuario> GetAll();

        public bool Exist(string valor);
    }
}
