using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.Enums;

namespace BookHaven.Models
{
    class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; } = 0;

        [Required]
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
