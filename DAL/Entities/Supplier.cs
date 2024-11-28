using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.DAL.Entities
{
    public class Supplier : AuditBase
    {
        [Display(Name = "Nombre del Proveedor")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        [Display(Name = "Correo Electrónico")]
        [EmailAddress(ErrorMessage = "El campo {0} debe contener una dirección de correo válida")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Email { get; set; }

        [Display(Name = "Teléfono")]
        [Phone(ErrorMessage = "El campo {0} debe contener un número de teléfono válido")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Phone { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string Address { get; set; }

        [Display(Name = "Productos")]
        public ICollection<Product>? Products { get; set; }
    }
}
