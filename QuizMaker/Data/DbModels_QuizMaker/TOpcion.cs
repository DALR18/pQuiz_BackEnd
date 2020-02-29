using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.DbModels_QuizMaker
{
    [Table("t_Opcion")]
    public partial class TOpcion
    {
        [Key]
        public int Id { get; set; }
        public int IdPregunta { get; set; }
        [Required]
        public string Texto { get; set; }
        [Column(TypeName = "decimal(6, 3)")]
        public decimal Valor { get; set; }
        public bool EsRespuestaDefecto { get; set; }
        public int OrdenRespuesta { get; set; }
        [StringLength(5)]
        public string Etiqueta { get; set; }

        [ForeignKey(nameof(IdPregunta))]
        [InverseProperty(nameof(TPregunta.TOpcion))]
        public virtual TPregunta IdPreguntaNavigation { get; set; }
    }
}
