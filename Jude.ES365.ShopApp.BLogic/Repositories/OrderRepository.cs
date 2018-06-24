using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Jude.ES365.ShopApp.BLogic.Interfaces;
using Jude.ES365.ShopApp.DatAcc.Models;

namespace Jude.ES365.ShopApp.BLogic.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataModelContext _context =  new DataModelContext();

        private double _orderTotalPrice = default(double);

        private int _numberOfItemsBought = 0;

        public Order GenerateOrder(List<Guid> customerPurchasedProducts)
        {

            var defaultCustomer = _context.Customers.First();

            var orderId = Guid.NewGuid();

            var createdOrder = new Order
            {
                ID = orderId,
                CreatedAt = DateTime.Now,
                IsOrderCancelled = false,
                IsOrderCompleted = true,
                CustomerId = defaultCustomer.ID,
                Customer = defaultCustomer,
                OrderProducts = ComputeOrderProducts(customerPurchasedProducts, orderId),
                TotalPayableAmout = _orderTotalPrice,
                NumberOfItemsPurchased = _numberOfItemsBought
            };
           

            try
            {
                _context.Orders.Add(createdOrder);
                _context.SaveChanges();
            }
            catch (Exception exc)
            {
                string message = exc.Message;
            }

            return createdOrder;
        }


        private List<OrderProduct> ComputeOrderProducts(List<Guid> selectedProductsIds, Guid orderid)
        {

            var orderProductsBox = new List<OrderProduct>();
            var products = _context.Products;
            
            var salePrice = default(double);

            foreach (var productId in selectedProductsIds)
            {
                var selectedProduct = products.Find(productId);

                var index = orderProductsBox.FindIndex(orderProd => orderProd.ProductId.Equals(selectedProduct.ID)
                                                                    && orderProd.OrderId.Equals(orderid));
                
                if (selectedProduct.SalePrice != null)
                {
                    salePrice = (double)(selectedProduct.SalePrice);
                }

                selectedProduct.Price = selectedProduct.IsOnSale ? salePrice : selectedProduct.Price;

                if (index >= 0)
                {
                    orderProductsBox[index].Quantity += 1;
                    orderProductsBox[index].TotalPrice += selectedProduct.Price;
                    orderProductsBox[index].Product = selectedProduct;
                }
                else
                {
                    orderProductsBox.Add(new OrderProduct
                    {
                        ProductId = selectedProduct.ID,
                        OrderId = orderid,
                        Quantity = 1,
                        TotalPrice = selectedProduct.Price,
                        Product = selectedProduct
                    });
                }

                _orderTotalPrice += selectedProduct.Price;
                _numberOfItemsBought++;
            }

            return orderProductsBox.ToList();
        }

     
        ~OrderRepository()
        {
            try
            {
                _context.Dispose();
            }
            catch (Exception exc)
            {
                String excption = exc.Message;
            }
        }
    }
}
