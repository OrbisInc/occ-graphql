using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Occ.Data.Entities
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        [StringLength(2000)]
        public string Notes { get; set; }

        public byte Quantity { get; set; }

        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }

        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }


    }


   

}
