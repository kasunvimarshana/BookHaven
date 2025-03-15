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
    class SalesService
    {
        private readonly SalesRepository _salesRepo = new SalesRepository();
        private readonly SalesDetailRepository _salesDetailRepo = new SalesDetailRepository();

        public List<Sale> GetAllSales() => _salesRepo.GetAllSales();

        public Sale? GetSaleById(int id) => _salesRepo.GetSaleById(id);

        public int CreateSale(Sale sale, SqlTransaction transaction = null)
            => _salesRepo.CreateSale(sale, transaction);

        public bool UpdateSale(Sale sale, SqlTransaction transaction = null)
            => _salesRepo.UpdateSale(sale, transaction);

        public bool DeleteSale(int id, SqlTransaction transaction = null) => _salesRepo.DeleteSale(id, transaction);

        public Sale? GetSaleWithSalesDetails(int saleId)
        {
            var sale = _salesRepo.GetSaleById(saleId);
            if (sale != null)
            {
                sale.SalesDetails = _salesDetailRepo.GetSalesDetailBySaleId(saleId);
            }
            return sale;
        }
    }
}
