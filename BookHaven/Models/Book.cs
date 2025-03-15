using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Models
{
    class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public string ISBN { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public int? SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
