using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jude.ES365.ShopApp.DatAcc.Models;

namespace Jude.ES365.ShopApp.ViewModels
{
    public class ProductViewModel
    {
        public List<SelectListItem> Categories { get; set; }

        public Product Product { get; set; }
    }
}