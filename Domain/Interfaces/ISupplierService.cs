using ProyectoFinal.DAL.Entities;

namespace ProyectoFinal.Domain.Interfaces
{
    public interface ISupplierService
    {
        // Obtener proveedor por ID
        Task<Supplier> GetSupplierByIdAsync(Guid id);

        // Obtener todos los proveedores
        Task<IEnumerable<Supplier>> GetSuppliersAsync();

        // Crear un nuevo proveedor
        Task<Supplier> CreateSupplierAsync(Supplier supplier);

        // Actualizar un proveedor existente
        Task<Supplier> UpdateSupplierAsync(Supplier supplier);

        // Eliminar un proveedor por ID
        Task<Supplier> DeleteSupplierAsync(Guid id);
    }
}
