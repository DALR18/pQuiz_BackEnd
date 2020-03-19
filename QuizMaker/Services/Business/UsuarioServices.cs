using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Domain.Bussines;
using Data.Repositories;

namespace Services.Bussines
{
    class UsuarioServices : IUsuarioServices
    {
        #region FIELDS
        [Dependency]
        public IUsuarioRepository usuarioRepository { get; set; }
        #endregion
        public bool Delete(int id)
        {
            return usuarioRepository.Delete(id);
        }

        public bool Exist(string valor)
        {
            return usuarioRepository.Exist(valor);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return usuarioRepository.GetAll();
        }

        public Usuario GetbyId(int id)
        {
            return usuarioRepository.GetbyId(id);
        }

        public bool save(Usuario u)
        {
            return usuarioRepository.save(u);
        }

        public bool Update(Usuario u)
        {
            return usuarioRepository.Update(u);
        }
    }
}
