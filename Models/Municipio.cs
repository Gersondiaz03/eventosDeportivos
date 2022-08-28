using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using MvcTorneo.Models;


namespace MvcMunicipio.Models
{
    [Index(nameof(nombre), IsUnique = true)]
    public class Municipio
    {
        [Key]
        [Required]
        [Display(Name = "Id del municipio")]
        public int municipioId { get; set; }
        [Required(ErrorMessage ="El campo '{0}' es obligatorio")]
        [StringLength(30, MinimumLength =4, ErrorMessage =" El campo '{0}' debe tener entre {2} y {1} caracteres.")]
        [Display(Name = "Nombre del municipio")]
        public string nombre { get; set; } = null!;
        
        [Display(Name = "Torneos realizados en el municipio")]
        [DisplayFormat(NullDisplayText = "No se han realizado torneos en este municipio.")]
        public List<Torneo> torneos { get; set; }
    }
}