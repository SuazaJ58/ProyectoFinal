using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.DAL.Entities
{
    public abstract class AuditBase
    {
        [Key]
        [Required]
        public virtual Guid Id { get; set; }

        [Required]
        public virtual DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public virtual DateTime? ModifiedDate { get; set; }
    }
}
