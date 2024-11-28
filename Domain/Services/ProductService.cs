using Microsoft.EntityFrameworkCore;
using ProyectoFinal.DAL;
using ProyectoFinal.DAL.Entities;
using ProyectoFinal.Domain.Interfaces;

namespace ProyectoFinal.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly DataBaseContext _context;

        public ProductService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsBySupplierIdAsync(Guid supplierId)
        {
            try
            {
                return await _context.Products.Where(p => p.SupplierId == supplierId).ToListAsync();
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            try
            {
                return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            try
            {
                product.Id = Guid.NewGuid();
                product.CreatedDate = DateTime.Now;
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            try
            {
                product.ModifiedDate = DateTime.Now;
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }

        public async Task<Product> DeleteProductAsync(Guid id)
        {
            try
            {
                var product = await GetProductByIdAsync(id);
                if (product == null) { return null; }
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }
    }
}
