using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.DAL;
using BookHaven.Models;

namespace BookHaven.BLL
{
    class SupplierService
    {
        private readonly SupplierRepository _supplierRepo = new SupplierRepository();

        public List<Supplier> GetAllSuppliers() => _supplierRepo.GetAllSuppliers();

        public Supplier? GetSupplierById(int id) => _supplierRepo.GetSupplierById(id);

        public bool CreateSupplier(Supplier supplier)
            => _supplierRepo.CreateSupplier(supplier);

        public bool UpdateSupplier(Supplier supplier)
            => _supplierRepo.UpdateSupplier(supplier);

        public bool DeleteSupplier(int id) => _supplierRepo.DeleteSupplier(id);
    }
}
