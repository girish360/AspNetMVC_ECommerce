using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jude.ES365.ShopApp.BLogic.Interfaces;

namespace Jude.ES365.ShopApp.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }


        public HomeController(ICategoryRepository repository) 
            : base(repository)
        {
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            TempData["CategoriesList"] = base.Categories;
        }
    }
}