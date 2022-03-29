using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCitasMedicas.Models
{
    public class Empleado
    {
        [Required]
        [Key]
        public int Id { get; set; } = default!;

        [Required]
        [StringLength(250)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(60)]
        public string Rol { get; set; } = string.Empty;

        [Required]
        public bool Activo { get; set; }

        [Required]
        [StringLength(150)]
        public string Correo { get; set; } = string.Empty;
    }
}
