using System;
using Jude.ES365.ShopApp.DatAcc.Models;

namespace Jude.ES365.ShopApp.BLogic.Interfaces
{
    public interface ICustomerRepository
    {

        Customer GetCustomerById(Guid id);

        Customer GetDefaultCustomer();

    }
}