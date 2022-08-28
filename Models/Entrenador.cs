using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MvcEquipo.Models;
using MvcPersona.Models;

namespace MvcEntrenador.Models
{
    public class Entrenador : Persona
    {
        [Required]
        [ForeignKey("equipoForeignKey")]
        [Display(Name = "Equipo al que pertenece el entrenador")]
        public int equipoId { get; set; }
        public Equipo equipo { get; set; }
    }
}