using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Occ.Data.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        [StringLength(4000)]
        public string Notes { get; set; }

        public DateTime  DateOrdered { get; set; }

        [StringLength(200)]
        public string DeliveryAddress { get; set; }

        [StringLength(20)]
        public string DeliveryPostalCode { get; set; }

        [StringLength(100)]
        public string DeliveryCity { get; set; }

        [StringLength(100)]
        public string DeliveryCountry { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        //[NotMapped]
        //public string PageInfo { get; set; }

    }
}
