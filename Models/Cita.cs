using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCitasMedicas.Models
{
    public class Cita
    {
        [Required]
        [Key]
        public int Id { get; set; } = default!;

        [Required]
        public DateTime? Fecha { get; set; } = default!;

        [Required]
        public DateTime? Hora { get; set; } = default!;

        [Required]
        [ForeignKey("PacienteId")]
        public int PacienteId { get; set; } = default!;

        public Paciente Paciente { get; set; } = default!;
    }
}
