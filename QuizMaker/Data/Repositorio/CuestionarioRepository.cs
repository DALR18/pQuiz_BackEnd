using Dominio.Business;
using System;
using System.Collections.Generic;
using System.Text;
using Data.DbModels_QuizMaker;
using System.Linq;
namespace Data.Repositorio
{
    class CuestionarioRepository : ICuestionarioRepository

    {

        #region Field
        private readonly DB_Context_QuizMaker db;



        public CuestionarioRepository()
        {
            db = new DB_Context_QuizMaker();
        }
        #endregion


        public bool Delete(int id)
        {
            try
            {
                var data = db.TCuestionario.Find(id);
                db.TCuestionario.Remove(data);
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
                var data = db.TCuestionario.Find(id);
                return data != null ? true : false;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IEnumerable<Cuestionario> GetAll()
        {
            try
            {
                var data = db.TCuestionario.Select(x => new Cuestionario()
                {
                    IdUsuarioCrea = x.IdUsuarioCrea,
                    Nombe = x.Nombe,
                    FechaCreacion = x.FechaCreacion,
                    Descripcion = x.Descripcion,
                });

                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public Cuestionario GetbyId(int id)
        {
            try
            {
                var data = db.TCuestionario.Find(id);
                return data != null ? ConverToBDDomain(data) : null;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool Save(Cuestionario b)
        {
            try
            {
                var dbTable = ConverToBDTable(b);
                db.TCuestionario.Add(dbTable);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Update(Cuestionario b)
        {
            try
            {
                var data = db.TCuestionario.Find(b.Id);
                if (data != null)
                {
                    db.TCuestionario.Update(ConverToBDTable(b));
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




        #region OtherMethos

        public TCuestionario ConverToBDTable(Cuestionario b)
        {
            return new TCuestionario
            {
                IdUsuarioCrea = b.IdUsuarioCrea,
                Nombe = b.Nombe,
                FechaCreacion = b.FechaCreacion,
                Descripcion = b.Descripcion,
            };
        }

        public Cuestionario ConverToBDDomain(TCuestionario b)
        {
            return new Cuestionario
            {
                IdUsuarioCrea = b.IdUsuarioCrea,
                Nombe = b.Nombe,
                FechaCreacion = b.FechaCreacion,
                Descripcion = b.Descripcion,

            };
        }



        #endregion

    }
}
