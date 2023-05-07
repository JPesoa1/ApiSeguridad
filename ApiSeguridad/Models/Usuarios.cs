using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSeguridad.Models
{
    [Table("UsuariosAux")]
    public class Usuarios
    {
        [Key]
        [Column("idusuario")]
        public int Id { get; set; }

        [Column("nombre")]
        public string nombre { get; set; }

        [Column("foto")]
        public string? foto { get; set; }
    }
}
