using System;
using System.Collections.Generic;
using Jude.ES365.ShopApp.DatAcc.Models;

namespace Jude.ES365.ShopApp.BLogic.Interfaces
{
    public interface IOrderRepository
    {
        Order GenerateOrder(List<Guid> customerPurchasedProducts);

    }
}