using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MvcEntrenador.Models;
using MvcTorneo.Models;
using MvcPatrocinador.Models;

namespace MvcEquipo.Models
{
    public class Equipo
    {
        [Key]
        public int equipoId { get; set; }
        [Required(ErrorMessage = "El campo {0}, es obligatorio")]
        [StringLength(40, MinimumLength = 4, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name = "Nombre del equipo")]
        public string nombre { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0}, es obligatorio")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name = "Deporte que practica el equipo")]
        public string deporte { get; set; } = null!;

        [ForeignKey("entrenadorForeignKey")]
        [Required]
        [Display(Name = "Entrenador del equipo")]
        public Entrenador entrenador { get; set; } = null!;

        [ForeignKey("patrocinadorForeignKey")]
        [Required]
        [Display(Name = "Patrocinador del equipo")]
        public int patrocinadorId { get; set; }
        public Patrocinador patrocinador { get; set; }

        public ICollection<Torneo> torneos { get; set; }
    }
}