using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jude.ES365.ShopApp.DataAccess.Models
{
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
