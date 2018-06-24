using System.Collections.Specialized;
using System.ComponentModel;
using System.Net.Mime;
using System.Web.Mvc;

namespace Jude.ES365.ShopApp.DatAcc.Models
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

        [Required(ErrorMessage = "Product code is required")]
        [StringLength(100)]
        [DisplayName("Product Code")]
        public string Code { get; set; }

        [StringLength(200)]
        [Required]
        [DisplayName("Product Name")]
        public string Name { get; set; }

        
        public string Description { get; set; }

        [DisplayName("Available in curent Stock ?")]
        public bool? IsStockAvailable { get; set; }

        
        public bool IsOnSale { get; set; }

        [Required]
        [DisplayName("Product Price")]
        public double Price { get; set; }

        [DisplayName("Product Sale Price")]
        public double ? SalePrice { get; set; } = default(double);
        
        public int NumberOfViewsByCustomer { get; set; }

   
        public decimal? Rating { get; set; }

        [DisplayName("Product Category")]
        public Guid? CategoryId { get; set; }

        [DisplayName("Product Category")]
        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductPhoto> ProductPhotoes { get; set; }
    }
}
