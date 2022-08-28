using System.ComponentModel.DataAnnotations;
using MvcPersona.Models;
using MvcEquipo.Models;

namespace MvcPatrocinador.Models
{
    public class Patrocinador : Persona
    {
        [Required(ErrorMessage = "El campo {0}, es obligatorio")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name = "Dirección del patrocinador")]
        public string direccion { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0}, es obligatorio")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name = "Tipo de persona")]
        public string tipoPersona { get; set; } = null!;
        
        [Display(Name = "Equipos que patrocina")]
        [DisplayFormat(NullDisplayText = "Actualmente no patrocina ningún equipo")]
        public List<Equipo> equipoPatrocinio { get; set; }
    }
}