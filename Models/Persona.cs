using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPersona.Models
{
    public class Persona
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Documento de identidad")]
        [Key]
        public int documento { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "El nombre no puede contener más de 50 carácteres.")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; } = null!;
        [Required]
        [StringLength(30, ErrorMessage = "Apellidos no puede contener más de 50 carácteres.")]
        [Display(Name = "Apellido")]
        public string apellido { get; set; } = null!;
        [Required]
        [Display(Name = "Género")]
        public char genero { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Teléfono")]
        [StringLength(10, ErrorMessage = "El número de teléfono no puede contener más de 10 carácteres.")]
        public string telefono { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(30, ErrorMessage = "La dirección de correo electrónico no puede contener más de 30 carácteres.")]
        [Display(Name = "Correo")]
        public string correo { get; set; }
    }
}