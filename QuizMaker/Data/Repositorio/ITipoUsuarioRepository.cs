using System;
using System.Collections.Generic;
using System.Text;
using Domain.Bussines;

namespace Data.Repositories
{
    public interface ITipoUsuarioRepository
    {
        public bool save(TipoUsuario tu);

        public TipoUsuario GetbyId(int id);

        public bool Delete(int id);

        public bool Update(TipoUsuario tu);

        public IEnumerable<TipoUsuario> GetAll();

        public bool Exist(string valor);
    }
}
