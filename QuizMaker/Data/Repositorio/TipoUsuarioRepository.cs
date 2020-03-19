using System;
using System.Collections.Generic;
using Domain.Bussines;
using Data.DbModels;
using System.Linq;

namespace Data.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        #region Field
        private readonly DBModels db;
        public TipoUsuarioRepository()
        {
            db = new DBModels();
        }
        #endregion
        public bool Delete(int id)
        {
            try
            {
                var data = db.TTipoUsuario.Find(id);
                db.TTipoUsuario.Remove(data);
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
                var data = db.TTipoUsuario.Find(valor);
                return data != null ? true : false;

            }
            catch (Exception)
            {
                return false;
                throw;
            } 
        }

        public IEnumerable<TipoUsuario> GetAll()
        {
            try
            {
                var data = db.TTipoUsuario.Select(x => new TipoUsuario()
                {
                    Id = x.Id,
                    Descriptor = x.Descriptor
                });

                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public TipoUsuario GetbyId(int id)
        {
            try
            {
                var data = db.TTipoUsuario.Find(id);
                return data != null ? ConverToBDDomainAuto(data) : null;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool save(TipoUsuario tu)
        {
            try
            {
                var dbTable = ConverToBDTableAuto(tu);
                db.TTipoUsuario.Add(dbTable);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Update(TipoUsuario tu)
        {
            try
            {
                var data = db.TTipoUsuario.Find(tu.Id);
                if (data != null)
                {
                    db.TTipoUsuario.Update(ConverToBDTableAuto(tu));
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

        public TTipoUsuario ConverToBDTableAuto(TipoUsuario tu)
        {
            return new TTipoUsuario
            {
                Id = tu.Id,
                Descriptor = tu.Descriptor 
            };
        }


        public TipoUsuario ConverToBDDomainAuto(TTipoUsuario tu)
        {
            return new TipoUsuario
            {
                Id = tu.Id,
                Descriptor = tu.Descriptor
            };
        }
    }
}
