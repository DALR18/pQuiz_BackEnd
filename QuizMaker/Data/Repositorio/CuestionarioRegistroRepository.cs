
using Data.DbModels_QuizMaker;
using Domain.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class CuestionarioRegistroRepository : ICuestionarioRegistroRepository
    {
        #region Fiels
        private readonly DB_Context_QuizMaker db;

        public CuestionarioRegistroRepository()
        {
            db = new DB_Context_QuizMaker();
        }
        public bool Delete(int id)
        {
            try
            {
                var data = db.TCuestionarioRegistro.Find(id);
                db.TCuestionarioRegistro.Remove(data);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Exist(int id)
        {
            try
            {
                var data = db.TCuestionarioRegistro.Find(id);
                return data != null ? true : false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IEnumerable<CuestionarioRegistro> GetAll()
        {
            try
            {
                var data = db.TCuestionarioRegistro.Select(x => new CuestionarioRegistro()
                {
                    Id = x.Id,
                    IdCuestionario = x.Id,
                    IdUsuario = x.IdUsuario,
                    FechaInicio = x.FechaInicio,
                    FechaFin = x.FechaFin,
                    Puntaje = x.Puntaje
                });

                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public CuestionarioRegistro GetbyId(int id)
        {
            try
            {
                var data = db.TCuestionarioRegistro.Find(id);
                return data != null ? ConvertToDBDDomain(data) : null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool save(CuestionarioRegistro c)
        {
            try
            {
                var dbtable = ConvertToDBTable(c);
                db.TCuestionarioRegistro.Add(dbtable);
                db.SaveChanges();

                int i = dbtable.Id;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Update(CuestionarioRegistro c)
        {
            try
            {
                var data = db.TCuestionarioRegistro.Find(c.Id);
                if (data != null)
                {

                    db.TCuestionarioRegistro.Update(ConvertToDBTable(c));
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

                throw;
            }
        }
        #endregion Other Methos

        public TCuestionarioRegistro ConvertToDBTable(CuestionarioRegistro c)
        {
            return new TCuestionarioRegistro
            {
                IdCuestionario = c.IdCuestionario,
                IdUsuario = c.IdUsuario,
                FechaInicio = c.FechaInicio,
                FechaFin = c.FechaFin,
                Puntaje = c.Puntaje
            };
        }
        public CuestionarioRegistro ConvertToDBDDomain(TCuestionarioRegistro c)
        {
            return new CuestionarioRegistro
            {
                IdCuestionario = c.IdCuestionario,
                IdUsuario = c.IdUsuario,
                FechaInicio = c.FechaInicio,
                FechaFin = c.FechaFin,
                Puntaje = c.Puntaje
            };
        }
    }
}
