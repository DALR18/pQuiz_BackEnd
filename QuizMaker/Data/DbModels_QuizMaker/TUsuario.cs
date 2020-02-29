using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.DbModels_QuizMaker
{
    [Table("t_Usuario")]
    public partial class TUsuario
    {
        public TUsuario()
        {
            TCuestionario = new HashSet<TCuestionario>();
            TCuestionarioRegistro = new HashSet<TCuestionarioRegistro>();
        }

        [Key]
        public int Id { get; set; }
        [Column("idTipoUsuario")]
        public int IdTipoUsuario { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Apellido { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        [InverseProperty(nameof(TTipoUsuario.TUsuario))]
        public virtual TTipoUsuario IdTipoUsuarioNavigation { get; set; }
        [InverseProperty("IdUsuarioCreaNavigation")]
        public virtual ICollection<TCuestionario> TCuestionario { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<TCuestionarioRegistro> TCuestionarioRegistro { get; set; }
    }
}
