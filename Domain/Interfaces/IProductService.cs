using ProyectoFinal.DAL.Entities;

namespace ProyectoFinal.Domain.Interfaces
{
    public interface IProductService
    {
        // Obtener producto por ID
        Task<Product> GetProductByIdAsync(Guid id);

        // Obtener todos los productos por ID de proveedor
        Task<IEnumerable<Product>> GetProductsBySupplierIdAsync(Guid supplierId);

        // Crear un nuevo producto
        Task<Product> CreateProductAsync(Product product);

        // Actualizar un producto existente
        Task<Product> UpdateProductAsync(Product product);

        // Eliminar un producto por ID
        Task<Product> DeleteProductAsync(Guid id);
    }
}
