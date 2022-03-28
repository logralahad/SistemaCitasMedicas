using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCitasMedicas.Models
{
    public class Paciente
    {
        [Required]
        [Key]
        public int Id { get; set; } = default!;

        [Required]
        [StringLength(150)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string Paterno { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string Materno { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Sexo { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string RFC { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        public string TipoSangre { get; set; } = string.Empty;

        [Required]
        public DateTime? FechaNac { get; set; } = default!;

        [Required]
        public bool? Alcoholismo { get; set; } = default!;

        [Required]
        public bool? Tabaquismo { get; set; } = default!;

        [Required]
        public bool? Toxicomania { get; set; } = default!;

        [Required]
        [StringLength(350)]
        public string Direccion { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string Telefono { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string Correo { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string CURP { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string Aseguradora { get; set; } = string.Empty;
    }
}
