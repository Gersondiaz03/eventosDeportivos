using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MvcEquipo.Models;
using MvcPersona.Models;

namespace MvcDeportista.Models
{
    public class Deportista : Persona
    {
        [Required(ErrorMessage = "El campo {0}, es obligatorio")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name = "Dirección del deportista")]
        public string direccion { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(3, ErrorMessage = "El RH del deportista no puede contener más de 3 carácteres.")]
        [Display(Name = "RH")]
        public string RH { get; set; } = null!;
        [DisplayFormat(NullDisplayText = "El deportista no cuenta con servicio de EPS actualmente")]
        [Display(Name = "Servicio de EPS")]
        public string EPS { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime fechaNacimiento { get; set; }
        
        [Required]
        [ForeignKey("equipoForeignKey")]
        [Display(Name = "Equipo al que pertenece el deportista")]
        public int equipoId { get; set; }
        public Equipo equipo { get; set; }
    }
}