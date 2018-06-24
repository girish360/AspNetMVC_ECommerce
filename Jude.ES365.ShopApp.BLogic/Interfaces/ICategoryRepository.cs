using System.Collections.Generic;

namespace Jude.ES365.ShopApp.BLogic.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<DatAcc.Models.Category> GetAllCategories();
    }
}