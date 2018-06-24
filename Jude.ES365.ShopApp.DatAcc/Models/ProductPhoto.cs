namespace Jude.ES365.ShopApp.DatAcc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductPhoto")]
    public partial class ProductPhoto
    {
        public Guid ID { get; set; }

        [Required]
        public string Filename { get; set; }

        public DateTime UploadedOn { get; set; }

        public Guid? ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
