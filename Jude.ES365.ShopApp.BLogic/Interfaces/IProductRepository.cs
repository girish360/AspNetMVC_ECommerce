using System;
using System.Collections.Generic;
using Jude.ES365.ShopApp.DatAcc.Models;

namespace Jude.ES365.ShopApp.BLogic.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product product);

        ICollection<Product> GetAllProduct();

        Product GetProductById(Guid id);

        ICollection<Product> GetProductsByNameSearch(string name);

        ICollection<Product> GetProductsByCategory(Guid categoryId);

        ICollection<Product> GetProductsByMaximumPrice(double maxprice);

        ICollection<Product> GetProductsOnSale();

    }
}