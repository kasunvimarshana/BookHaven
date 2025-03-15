using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.Enums;

namespace BookHaven.Models
{
    class Order
    {
        public int Id { get; set; }

        public int SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public decimal TotalAmount { get; set; } = 0;

        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
