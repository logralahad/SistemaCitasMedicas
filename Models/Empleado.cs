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
        [StringLength(150)]
        public bool? Activo { get; set; } = default!;
    }
}
