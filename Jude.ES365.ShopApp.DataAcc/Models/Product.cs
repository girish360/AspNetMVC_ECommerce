namespace Jude.ES365.ShopApp.DataAcc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
            ProductPhotoes = new HashSet<ProductPhoto>();
        }

        public Guid ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Code { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool? IsStockAvailable { get; set; }

        public bool? IsOnSale { get; set; }

        public decimal Price { get; set; }

        public decimal? SalePrice { get; set; }

        public int NumberOfViewsByCustomer { get; set; }

        public decimal? Rating { get; set; }

        public Guid? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductPhoto> ProductPhotoes { get; set; }
    }
}
