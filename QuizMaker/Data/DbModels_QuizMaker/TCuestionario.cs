using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.DbModels_QuizMaker
{
    [Table("t_Cuestionario")]
    public partial class TCuestionario
    {
        public TCuestionario()
        {
            TCuestionarioRegistro = new HashSet<TCuestionarioRegistro>();
            TPregunta = new HashSet<TPregunta>();
        }

        [Key]
        public int Id { get; set; }
        [Column("idUsuarioCrea")]
        public int IdUsuarioCrea { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombe { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaCreacion { get; set; }
        public string Descripcion { get; set; }

        [ForeignKey(nameof(IdUsuarioCrea))]
        [InverseProperty(nameof(TUsuario.TCuestionario))]
        public virtual TUsuario IdUsuarioCreaNavigation { get; set; }
        [InverseProperty("IdCuestionarioNavigation")]
        public virtual ICollection<TCuestionarioRegistro> TCuestionarioRegistro { get; set; }
        [InverseProperty("IdCuestionarioNavigation")]
        public virtual ICollection<TPregunta> TPregunta { get; set; }
    }
}
