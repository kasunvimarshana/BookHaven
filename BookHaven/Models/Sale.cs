using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Models
{
    class Sale
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal Discount { get; set; } = 0;

        public DateTime SaleDate { get; set; } = DateTime.Now;

        public List<SalesDetail> SalesDetails { get; set; }
    }
}
