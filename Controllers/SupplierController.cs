using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.DAL.Entities;
using ProyectoFinal.Domain.Interfaces;

namespace ProyectoFinal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : Controller
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliersAsync()
        {
            var suppliers = await _supplierService.GetSuppliersAsync();
            if (suppliers == null || !suppliers.Any()) return NotFound();
            return Ok(suppliers);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<Supplier>> GetSupplierByIdAsync(Guid id)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            if (supplier == null) return NotFound();
            return Ok(supplier);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Supplier>> CreateSupplierAsync(Supplier supplier)
        {
            try
            {
                var newSupplier = await _supplierService.CreateSupplierAsync(supplier);
                if (newSupplier == null) return NotFound();
                return Ok(newSupplier);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    return Conflict(String.Format("{0} ya existe", supplier.Name));
                }
                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Update")]
        [Route("Update")]
        public async Task<ActionResult<Supplier>> UpdateSupplierAsync(Supplier supplier)
        {
            try
            {
                var editedSupplier = await _supplierService.UpdateSupplierAsync(supplier);
                if (editedSupplier == null) return NotFound();
                return Ok(editedSupplier);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    return Conflict(String.Format("{0} ya existe", supplier.Name));
                }
                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete/{id}")]
        public async Task<ActionResult<Supplier>> DeleteSupplierAsync(Guid id)
        {
            if (id == null) return BadRequest();
            var deletedSupplier = await _supplierService.DeleteSupplierAsync(id);
            if (deletedSupplier == null) return NotFound();
            return Ok(deletedSupplier);
        }
    }
}
