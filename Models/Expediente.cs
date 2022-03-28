using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCitasMedicas.Models
{
    public class Expediente
    {
        [Required]
        [Key]
        public int Id { get; set; } = default!;

        [Required]
        [ForeignKey("PacienteId")]
        public int PacienteId { get; set; } = default!;

        public Paciente Paciente { get; set; } = default!;

        [Required]
        [ForeignKey("EmpleadoId")]
        public int EmpleadoId { get; set; } = default!;

        public Empleado Empleado { get; set; } = default!;

        [Required]
        public int Presion1 { get; set; } = default!;

        [Required]
        public int Presion2 { get; set; } = default!;

        [Required]
        public decimal Peso { get; set; } = default!;

        [Required]
        public int Altura { get; set; } = default!;

        [Required]
        [StringLength(200)]
        public string CronicoDegenerativa { get; set; } = string.Empty;

        [Required]
        [StringLength(400)]
        public string Operaciones { get; set; } = string.Empty;

        [Required]
        [StringLength(300)]
        public string Alergias { get; set; } = string.Empty;

        [Required]
        [StringLength(300)]
        public string Reflejos { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Movimientos { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Observaciones { get; set; } = string.Empty;
    }
}
