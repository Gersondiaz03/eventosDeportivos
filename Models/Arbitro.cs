using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MvcPersona.Models;
using MvcTorneo.Models;
using MvcColegioArbitral.Models;

namespace MvcArbitro.Models
{
    public class Arbitro : Persona
    {
        [Required]
        [StringLength(30, ErrorMessage = "El nombre no puede contener más de 50 carácteres.")]
        [Display(Name = "Deporte en el que ejerce el arbitro")]
        public string deporte { get; set; } = null!;

        [Required]
        [Display(Name = "Id de torneo en el que ejerce el arbitro")]
        public int torneoId { get; set; }
        public Torneo torneo { get; set; } = null!;

        [Required]
        [Display(Name = "Colegio donde se graduó el arbitro")]	
        [ForeignKey("colegioArbitralForeignKey")]
        public int colegioArbitralId { get; set; }
        public colegioArbitral colegioArbitral { get; set; }

    }
}