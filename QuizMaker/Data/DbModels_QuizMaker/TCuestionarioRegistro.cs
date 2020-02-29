using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.DbModels_QuizMaker
{
    [Table("t_CuestionarioRegistro")]
    public partial class TCuestionarioRegistro
    {
        public TCuestionarioRegistro()
        {
            TRespuesta = new HashSet<TRespuesta>();
        }

        [Key]
        public int Id { get; set; }
        public int IdCuestionario { get; set; }
        public int IdUsuario { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaInicio { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaFin { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? Puntaje { get; set; }

        [ForeignKey(nameof(IdCuestionario))]
        [InverseProperty(nameof(TCuestionario.TCuestionarioRegistro))]
        public virtual TCuestionario IdCuestionarioNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(TUsuario.TCuestionarioRegistro))]
        public virtual TUsuario IdUsuarioNavigation { get; set; }
        [InverseProperty("IdCuestionarioRegistroNavigation")]
        public virtual ICollection<TRespuesta> TRespuesta { get; set; }
    }
}
