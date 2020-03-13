using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Business
{
  public  class Respuesta
    {

        public int Id { get; set; }
        public int IdCuestionarioRegistro { get; set; }
        public int IdPregunta { get; set; }
        public string Texto { get; set; }
        [Column(TypeName = "decimal(6, 3)")]
        public decimal? Valor { get; set; }

       // [ForeignKey(nameof(IdCuestionarioRegistro))]
       // [InverseProperty(nameof(TCuestionarioRegistro.TRespuesta))]
        //public virtual TCuestionarioRegistro IdCuestionarioRegistroNavigation { get; set; }
        //[ForeignKey(nameof(IdPregunta))]
        //[InverseProperty(nameof(TPregunta.TRespuesta))]
        //public virtual TPregunta IdPreguntaNavigation { get; set; }

    }
}
