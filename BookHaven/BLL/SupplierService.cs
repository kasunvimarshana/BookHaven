using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BookHaven.DAL;
using BookHaven.Models;

namespace BookHaven.BLL
{
    class SupplierService
    {
        private readonly SupplierRepository _supplierRepo = new SupplierRepository();

        public List<Supplier> GetAllSuppliers() => _supplierRepo.GetAllSuppliers();

        public Supplier? GetSupplierById(int id) => _supplierRepo.GetSupplierById(id);

        public int CreateSupplier(Supplier supplier, SqlTransaction transaction = null)
            => _supplierRepo.CreateSupplier(supplier, transaction);

        public bool UpdateSupplier(Supplier supplier, SqlTransaction transaction = null)
            => _supplierRepo.UpdateSupplier(supplier, transaction);

        public bool DeleteSupplier(int id, SqlTransaction transaction = null) => _supplierRepo.DeleteSupplier(id, transaction);
    }
}
