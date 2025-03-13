using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Models
{
    class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }

        [Required, StringLength(20)]
        public string OrderStatus { get; set; } = "Pending";
    }
}
