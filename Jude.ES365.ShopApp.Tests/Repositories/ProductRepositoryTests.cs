using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jude.ES365.ShopApp.BLogic.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jude.ES365.ShopApp.Tests.Repositories
{
    [TestClass]
    public class ProductRepositoryTests
    {
        private CategoryRepository _categoryRepository = null;
        private ProductRepository _productRepository = null;

        [TestInitialize]
        public void TestInitialize()
        {
            _categoryRepository = new CategoryRepository();
            _productRepository = new ProductRepository();

            //Seed 
        }

        [TestMethod]
        public void GetAllProduct_ShouldReturnListOfProducts()
        {

        }

        ~ProductRepositoryTests()
        {
            //Delete Test Seed Data
        }


    }
}
