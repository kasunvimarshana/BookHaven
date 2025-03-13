using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Models
{
    class Book
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string Title { get; set; }

        [Required, StringLength(100)]
        public string Author { get; set; }

        [StringLength(50)]
        public string Genre { get; set; }

        [Required, StringLength(20)]
        public string ISBN { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        public int? SupplierID { get; set; }

        [ForeignKey("SupplierID")]
        public virtual Supplier Supplier { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
