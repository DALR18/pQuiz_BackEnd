using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.DbModels_QuizMaker
{
    [Table("t_Pregunta")]
    public partial class TPregunta
    {
        public TPregunta()
        {
            TOpcion = new HashSet<TOpcion>();
            TRespuesta = new HashSet<TRespuesta>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Texto { get; set; }
        [Column("idTipoPregunta")]
        public int IdTipoPregunta { get; set; }
        public int? Orden { get; set; }
        public string Instrucciones { get; set; }
        [Column("idCuestionario")]
        public int? IdCuestionario { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? Peso { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? RangoMaximo { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? RangoMinimo { get; set; }

        [ForeignKey(nameof(IdCuestionario))]
        [InverseProperty(nameof(TCuestionario.TPregunta))]
        public virtual TCuestionario IdCuestionarioNavigation { get; set; }
        [InverseProperty("IdPreguntaNavigation")]
        public virtual ICollection<TOpcion> TOpcion { get; set; }
        [InverseProperty("IdPreguntaNavigation")]
        public virtual ICollection<TRespuesta> TRespuesta { get; set; }
    }
}
