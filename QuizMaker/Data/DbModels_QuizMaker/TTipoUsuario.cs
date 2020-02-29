using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.DbModels_QuizMaker
{
    [Table("t_TipoUsuario")]
    public partial class TTipoUsuario
    {
        public TTipoUsuario()
        {
            TUsuario = new HashSet<TUsuario>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        public string Descriptor { get; set; }

        [InverseProperty("IdTipoUsuarioNavigation")]
        public virtual ICollection<TUsuario> TUsuario { get; set; }
    }
}
