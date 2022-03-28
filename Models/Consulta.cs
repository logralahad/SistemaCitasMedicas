using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCitasMedicas.Models
{
    public class Consulta
    {
        [Required]
        [Key]
        public int Id { get; set; } = default!;

        [Required]
        public DateTime? Fecha { get; set; } = default!;

        [Required]
        public int Presion1 { get; set; } = default!;

        [Required]
        public int Presion2 { get; set; } = default!;

        [Required]
        public float Peso { get; set; } = default!;

        [Required]
        public int Altura { get; set; } = default!;

        [Required]
        [ForeignKey("PacienteId")]
        public int PacienteId { get; set; } = default!;

        public Paciente Paciente { get; set; } = default!;

        [Required]
        [StringLength(300)]
        public string Sintomas { get; set; } = string.Empty;

        [Required]
        [StringLength(400)]
        public string Diagnostico { get; set; } = string.Empty;

        [Required]
        [StringLength(300)]
        public string Medicamentos { get; set; } = string.Empty;
    }
}
