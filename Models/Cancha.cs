using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MvcEscenario.Models;

namespace MvcCancha.Models
{
    public class Cancha
    {
        [Required]
        [Display(Name = "Id de la cancha")]
        [Key]
        public int canchaId { get; set; }
        [Required(ErrorMessage = "El campo {0}, es obligatorio")]
        [StringLength(40, MinimumLength = 4, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name = "Nombre de la cancha")]
        public string nombre { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0}, es obligatorio")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name = "Deporte que se practica en la cancha")]
        public string disciplina { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0}, es obligatorio")]
        [Display(Name = "Cantidad de espectadores de la cancha")]
        public int cantidadEspectadores { get; set; }
        [Required(ErrorMessage = "El campo {0}, es obligatorio")]
        [Display(Name = "Medidas de la cancha")]
        public string medidas { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0}, es obligatorio")]
        [Display(Name = "Escenario que se practica en la cancha")]
        [ForeignKey("escenarioForeignKey")]
        public int escenarioId { get; set; }
        public Escenario escenario { get; set; }

    }
}