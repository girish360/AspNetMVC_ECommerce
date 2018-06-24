namespace Jude.ES365.ShopApp.DataAcc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderProduct")]
    public partial class OrderProduct
    {
        [Key]
        [Column(Order = 0)]
        public Guid OrderId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid ProductId { get; set; }

        public int? Quantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
