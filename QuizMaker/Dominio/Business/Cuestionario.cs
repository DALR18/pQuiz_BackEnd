using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Business
{
   public  class Cuestionario
    {
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
