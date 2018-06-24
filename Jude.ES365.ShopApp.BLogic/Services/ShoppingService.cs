using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jude.ES365.ShopApp.DatAcc.Models;

namespace Jude.ES365.ShopApp.BLogic.Services
{
    public class ShoppingService
    {
        private readonly DataModelContext _context = null;

        public ShoppingService()
        {
            _context = new DataModelContext();
        }

    }
}
