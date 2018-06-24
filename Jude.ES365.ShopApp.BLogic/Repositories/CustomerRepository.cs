using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jude.ES365.ShopApp.BLogic.Interfaces;
using Jude.ES365.ShopApp.DatAcc.Models;

namespace Jude.ES365.ShopApp.BLogic.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataModelContext _context = new DataModelContext();
        public Customer GetCustomerById(Guid id)
        {
            return _context.Customers.AsNoTracking().SingleOrDefault(cust => cust.ID.Equals(id));
        }

        public Customer GetDefaultCustomer()
        {
            return _context.Customers.FirstOrDefault();
        }

        ~CustomerRepository()
        {

            try
            {
                _context.Dispose();
            }
            catch (Exception exc)
            {
                string excMessage = exc.Message;
            }
        }
    }
}
