using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Models
{
    class SalesDetail
    {
        public int Id { get; set; }

        public int SaleId { get; set; }

        public virtual Sale Sale { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Subtotal => Quantity * Price;
    }
}
