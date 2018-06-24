using Jude.ES365.ShopApp.BLogic.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jude.ES365.ShopApp.Tests.Repositories
{
    [TestClass]
    public class CategoryRepositoryTest
    {

        [TestMethod]
        public void GetAllCategory_ShouldReturn_ListOfTypeCategory()
        {
            // Categories are seeded so there should be always an item
            var categoryRepo = new CategoryRepository();

            var testResult = categoryRepo.GetAllCategories();

            Assert.IsTrue(testResult.Count > 0, "Test failed, list returned does not contain any category item");
            Assert.IsNotNull(testResult, "Test Failed : Returned null ");
        }

    
    }
}
