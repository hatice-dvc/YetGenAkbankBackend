using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productify.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedOn { get; set; }

        public Product(string name, decimal price, string description, int stockQuantity)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Description = description;
            StockQuantity = stockQuantity;
            CreatedOn = DateTime.Now;
        }
    }
}
