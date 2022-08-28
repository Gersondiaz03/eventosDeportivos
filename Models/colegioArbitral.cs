using System.ComponentModel.DataAnnotations;
using MvcArbitro.Models;

namespace MvcColegioArbitral.Models
{
    public class colegioArbitral
    {
        [Key]
        [Display(Name = "Id del colegio arbitral")]
        public int colegioArbitralId { get; set; }
        [Required(ErrorMessage = "El campo {0}, es obligatorio")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name = "NIT del colegio arbitral")]
        public string NIT { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0}, es obligatorio")]
        [StringLength(40, MinimumLength = 4, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name = "Nombre del colegio arbitral")]
        public string nombre { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0}, es obligatorio")]
        [StringLength(40, MinimumLength = 4, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name = "Número de resolución del colegio arbitral")]
        public string resolucion { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0}, es obligatorio")]
        [StringLength(40, MinimumLength = 4, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name = "Dirección del colegio arbitral")]
        public string direccion { get; set; } = null!;

        [DataType(DataType.PhoneNumber)]
        [StringLength(10, ErrorMessage = "El número de teléfono no puede contener más de 10 carácteres.")]
        [DisplayFormat(NullDisplayText = "No existe número de teléfono")]
        [Display(Name = "Número de teléfono")]
        public string telefono { get; set; }
        [DataType(DataType.EmailAddress)]
        [StringLength(30, ErrorMessage = "El correo electrónico no puede contener más de 10 carácteres.")]
        [DisplayFormat(NullDisplayText = "No existe correo electrónico")]
        [Display(Name = "Correo electrónico")]
        public string correo { get; set; }
        public List<Arbitro> arbitrosColegio { get; set; }
    }
}