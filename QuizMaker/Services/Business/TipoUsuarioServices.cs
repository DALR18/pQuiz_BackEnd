using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Domain.Bussines;
using Data.Repositories;

namespace Services.Bussines
{
    public class TipoUsuarioServices : ITipoUsuarioServices
    {
        #region FIELDS
        [Dependency]
        public ITipoUsuarioRepository tipoUsuarioRepository { get; set; }
        #endregion
        public bool Delete(int id)
        {
            return tipoUsuarioRepository.Delete(id);
        }

        public bool Exist(string valor)
        {
            return tipoUsuarioRepository.Exist(valor);
        }

        public IEnumerable<TipoUsuario> GetAll()
        {
            return tipoUsuarioRepository.GetAll();
        }

        public TipoUsuario GetbyId(int id)
        {
            return tipoUsuarioRepository.GetbyId(id);
        }

        public bool save(TipoUsuario tu)
        {
            return tipoUsuarioRepository.save(tu);
        }

        public bool Update(TipoUsuario tu)
        {
            return tipoUsuarioRepository.Update(tu);
        }
    }
}
