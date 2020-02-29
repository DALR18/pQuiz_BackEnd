using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.DbModels_QuizMaker
{
    [Table("t_Respuesta")]
    public partial class TRespuesta
    {
        [Key]
        public int Id { get; set; }
        public int IdCuestionarioRegistro { get; set; }
        public int IdPregunta { get; set; }
        public string Texto { get; set; }
        [Column(TypeName = "decimal(6, 3)")]
        public decimal? Valor { get; set; }

        [ForeignKey(nameof(IdCuestionarioRegistro))]
        [InverseProperty(nameof(TCuestionarioRegistro.TRespuesta))]
        public virtual TCuestionarioRegistro IdCuestionarioRegistroNavigation { get; set; }
        [ForeignKey(nameof(IdPregunta))]
        [InverseProperty(nameof(TPregunta.TRespuesta))]
        public virtual TPregunta IdPreguntaNavigation { get; set; }
    }
}
