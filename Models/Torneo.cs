using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MvcMunicipio.Models;
using MvcEquipo.Models;

namespace MvcTorneo.Models
{
    [Index(nameof(nombre), IsUnique = true)]
    public class Torneo
    {
        [Key]
        public int torneoId { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(20, MinimumLength =4, ErrorMessage ="El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name = "Nombre del torneo")]
        public string nombre { get; set; } = null!;
        
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(20, MinimumLength =4, ErrorMessage ="El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name = "Categoría del equipo")]
        public string categoria { get; set; } = null!;

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de inicio")]
        public DateTime fechaInicio { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha final")]
        public DateTime fechaFinal { get; set; }

        [ForeignKey("municipioForeignKey")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Municipio donde se realiza el torneo")]
        public int municipioId { get; set; }
        public Municipio municipio { get; set; }

        public ICollection<Equipo> equipos { get; set; }
    }
}