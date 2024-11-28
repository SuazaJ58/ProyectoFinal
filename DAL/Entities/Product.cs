using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.DAL.Entities
{
    public class Product : AuditBase
    {
        [Display(Name = "Nombre del Producto")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string Description { get; set; }

        [Display(Name = "Precio")]
        [Range(0, double.MaxValue, ErrorMessage = "El campo {0} debe ser un valor positivo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal Price { get; set; }

        [Display(Name = "Stock Disponible")]
        [Range(0, int.MaxValue, ErrorMessage = "El campo {0} debe ser un valor positivo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Stock { get; set; }

        // Relación con Supplier
        [Display(Name = "Proveedor")]
        public Supplier? Supplier { get; set; }

        [Display(Name = "ID Proveedor")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public Guid SupplierId { get; set; }
    }
}
