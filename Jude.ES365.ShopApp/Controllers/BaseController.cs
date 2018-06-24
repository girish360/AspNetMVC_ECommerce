using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jude.ES365.ShopApp.BLogic.Interfaces;
using Jude.ES365.ShopApp.DatAcc.Models;

namespace Jude.ES365.ShopApp.Controllers
{
    public class BaseController : Controller
    {

        public ICollection<Category> Categories = null;
        public BaseController(ICategoryRepository repository)
        {
            var categoryRepository = repository;

            Categories = categoryRepository.GetAllCategories();
            
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            if (Session["ProductsCart"] != null)
            {
                var existingCart = (List<Guid>)Session["ProductsCart"];
                Session["CartCount"] = "[" + existingCart.Count + "]";
            }
            else
            {
                Session["CartCount"] = "[0]";
            }
        }
    }
}