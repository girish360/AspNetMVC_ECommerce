using System.Collections.Generic;
using System.Linq;
using Jude.ES365.ShopApp.BLogic.Interfaces;
using Jude.ES365.ShopApp.DatAcc.Models;

namespace Jude.ES365.ShopApp.BLogic.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly  DataModelContext _context = new DataModelContext();
        public ICollection<Category> GetAllCategories()
        {
            var categories = _context.Categories.ToList();

            return categories;
        }
    }
}
