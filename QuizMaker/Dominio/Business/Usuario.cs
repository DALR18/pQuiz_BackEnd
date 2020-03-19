using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Bussines
{
    public class Usuario
    {
        public int Id { get; set; }
        public int IdTipoUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
