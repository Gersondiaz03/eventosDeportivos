using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MvcTorneo.Models;
using MvcCancha.Models;

namespace MvcEscenario.Models
{
    public class Escenario
    {
        [Key]
        [Required]
        [Display(Name = "Id del escenario")]
        public int escenarioId { get; set; }
        [Required(ErrorMessage = "El campo {0}, es obligatorio")]
        [StringLength(40, MinimumLength = 4, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name = "Nombre del escenario")]
        public string nombre { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0}, es obligatorio")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name = "Dirección del escenario")]
        public string direccion { get; set; } = null!;

        [Display(Name = "Número de teléfono")]
        [DisplayFormat(NullDisplayText = "No hay número de teléfono disponible")]
        public string telefono { get; set; }

        [Display(Name = "Torneo que se realiza en esta cancha")]
        [ForeignKey("torneoForeignKey")]
        public int torneoId { get; set; }
        public Torneo torneo { get; set; }

        public List<Cancha> listaCanchas { get; set; }
    }
}