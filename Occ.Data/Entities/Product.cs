using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Occ.Data.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(9, 2)")]
        public decimal Price { get; set; }
        public ProductType Type { get; set; }
        public List<OrderItem> OrderItems { get; set; }

    }
    public enum ProductType
    {
        Shirt = 1,
        Boots = 2,
        Shoes = 3,
        Hat = 4
    }

}
