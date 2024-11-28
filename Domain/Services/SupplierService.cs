using Microsoft.EntityFrameworkCore;
using ProyectoFinal.DAL;
using ProyectoFinal.DAL.Entities;
using ProyectoFinal.Domain.Interfaces;

namespace ProyectoFinal.Domain.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly DataBaseContext _context;

        public SupplierService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supplier>> GetSuppliersAsync()
        {
            try
            {
                return await _context.Suppliers.ToListAsync();
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }

        public async Task<Supplier> GetSupplierByIdAsync(Guid id)
        {
            try
            {
                return await _context.Suppliers.FirstOrDefaultAsync(s => s.Id == id);
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }

        public async Task<Supplier> CreateSupplierAsync(Supplier supplier)
        {
            try
            {
                supplier.Id = Guid.NewGuid();
                supplier.CreatedDate = DateTime.Now;
                _context.Suppliers.Add(supplier);
                await _context.SaveChangesAsync();
                return supplier;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }

        public async Task<Supplier> UpdateSupplierAsync(Supplier supplier)
        {
            try
            {
                supplier.ModifiedDate = DateTime.Now;
                _context.Suppliers.Update(supplier);
                await _context.SaveChangesAsync();
                return supplier;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }

        public async Task<Supplier> DeleteSupplierAsync(Guid id)
        {
            try
            {
                var supplier = await GetSupplierByIdAsync(id);
                if (supplier == null) { return null; }
                _context.Suppliers.Remove(supplier);
                await _context.SaveChangesAsync();
                return supplier;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }
    }
}
