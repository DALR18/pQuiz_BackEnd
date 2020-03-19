using Domain.Bussines;
using System;
using System.Collections.Generic;
using System.Text;
using Data.DbModels;
using System.Linq;

namespace Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        #region Field
        private readonly DBModels db;
        public UsuarioRepository()
        {
            db = new DBModels();
        }
        #endregion
        public bool Delete(int id)
        {
            try
            {
                var data = db.TUsuario.Find(id);
                db.TUsuario.Remove(data);
                db.SaveChanges();
                return true;
            }


            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Exist(string valor)
        {
            try
            {
                var data = db.TUsuario.Find(valor);
                return data != null ? true : false;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IEnumerable<Usuario> GetAll()
        {
            try
            {
                var data = db.TUsuario.Select(x => new Usuario()
                {
                    IdTipoUsuario = x.IdTipoUsuario,
                    Nombre = x.Nombre,
                    Apellido = x.Apellido
                });

                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public Usuario GetbyId(int id)
        {
            try
            {
                var data = db.TUsuario.Find(id);
                return data != null ? ConverToBDDomainAuto(data) : null;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool save(Usuario u)
        {
            try
            {
                var dbTable = ConverToBDTableAuto(u);
                db.TUsuario.Add(dbTable);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Update(Usuario u)
        {
            try
            {
                var data = db.TUsuario.Find(u.Id);
                if (data != null)
                {
                    db.TUsuario.Update(ConverToBDTableAuto(u));
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public TUsuario ConverToBDTableAuto(Usuario u)
        {
            return new TUsuario
            {
                IdTipoUsuario = u.IdTipoUsuario,
                Nombre = u.Nombre,
                Apellido = u.Apellido
            };
        }


        public Usuario ConverToBDDomainAuto(TUsuario u)
        {
            return new Usuario
            {
                IdTipoUsuario = u.IdTipoUsuario,
                Nombre = u.Nombre,
                Apellido = u.Apellido
            };
        }
    }
}
