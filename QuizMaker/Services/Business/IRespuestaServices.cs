﻿using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Business;

namespace Services.Business
{
   public interface IRespuestaServices
    {
        public bool Save(Respuesta c);

        public Respuesta GetbyId(int id);

        public bool Delete(int id);

        public bool Update(Respuesta c);

        public IEnumerable<Respuesta> GetAll();

        public bool Exist(string valor);
    }
}
