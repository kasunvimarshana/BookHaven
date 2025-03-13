using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Models
{
    class SalesDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SaleID { get; set; }

        [ForeignKey("SaleID")]
        public virtual Sale Sale { get; set; }

        [Required]
        public int BookID { get; set; }

        [ForeignKey("BookID")]
        public virtual Book Book { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal Subtotal => Quantity * Price;
    }
}
