using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jude.ES365.ShopApp.BLogic.Interfaces;
using Jude.ES365.ShopApp.DatAcc.Models;

namespace Jude.ES365.ShopApp.BLogic.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataModelContext _context = null;

        public ProductRepository()
        {
            _context = new DataModelContext();
        }
        public void AddProduct(Product product)
        {
            product.ID = Guid.NewGuid();
            _context.Products.Add(product);
            _context.SaveChanges();

        }

        public ICollection<Product> GetAllProduct()
        {
            return _context.Products.OrderBy(prod => prod.Name).ToList();
        }

        public Product GetProductById(Guid id)
        {
            return _context.Products.Find(id);
        }

        public ICollection<Product> GetProductsByNameSearch(string name)
        {
            return _context.Products.Where(prod => prod.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
        }

        public ICollection<Product> GetProductsByAnySearch(string hint)
        {
            return _context.Products.Where(prod => prod.Name.Contains(hint) || prod.Category.ShortName.Contains(hint) || prod.Description.Contains(hint))
                .ToList();
        }

        public ICollection<Product> GetProductsByCategory(Guid categoryId)
        {
            return _context.Products.Where(prod => prod.Category.ID.Equals(categoryId)).ToList();
        }

        public ICollection<Product> GetProductsByMaximumPrice(double maxprice)
        {
            return _context.Products.Where(prod => prod.Price > maxprice).ToList();
        }

        public ICollection<Product> GetProductsOnSale()
        {
            return _context.Products.Where(prod => prod.IsOnSale.Equals(true)).ToList();
        }
    }
}
