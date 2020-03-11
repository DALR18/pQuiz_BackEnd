using Dominio.Business;
using System;
using System.Collections.Generic;
using System.Text;
using Data.DbModels_QuizMaker;
using System.Linq;
namespace Data.Repositorio

{
   public class RespuestaRepository : IRespuestaRepository
    {

        #region Field
        private readonly DB_Context_QuizMaker db;



        public RespuestaRepository()
        {
            db = new DB_Context_QuizMaker();
        }
        #endregion

        public bool Delete(int id)
        {
            try
            {
                var data = db.TRespuesta.Find(id);
                db.TRespuesta.Remove(data);
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
                var data = db.TRespuesta.Find(id);
                return data != null ? true : false;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IEnumerable<Respuesta> GetAll()
        {
            try
            {
                var data = db.TRespuesta.Select(x => new Respuesta()
                {
                    IdCuestionarioRegistro = x.IdCuestionarioRegistro,
                    IdPregunta = x.IdPregunta,
                    Texto = x.Texto,
                    Valor = x.Valor
                });

                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public Respuesta GetbyId(int id)
        {
            try
            {
                var data = db.TRespuesta.Find(id);
                return data != null ? ConverToBDDomain(data) : null;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool Save(Respuesta b)
        {
            try
            {
                var dbTable = ConverToBDTable(b);
                db.TRespuesta.Add(dbTable);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Update(Respuesta b)
        {
            try
            {
                var data = db.TRespuesta.Find(b.Id);
                if (data != null)
                {
                    db.TRespuesta.Update(ConverToBDTable(b));
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

        public TRespuesta ConverToBDTable(Respuesta b)
        {
            return new TRespuesta
            {
              IdCuestionarioRegistro = b.IdCuestionarioRegistro,
                IdPregunta = b.IdPregunta,
                Texto = b.Texto,
                Valor = b.Valor

            };
        }

        public Respuesta ConverToBDDomain(TRespuesta b)
        {
            return new Respuesta
            {
                IdCuestionarioRegistro = b.IdCuestionarioRegistro,
                IdPregunta = b.IdPregunta,
                Texto = b.Texto,
                Valor = b.Valor

            };
        }


        #endregion



    }
}