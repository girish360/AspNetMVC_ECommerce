using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Jude.ES365.ShopApp.BLogic.Interfaces;
using Jude.ES365.ShopApp.DatAcc.Models;
using Jude.ES365.ShopApp.ViewModels;

namespace Jude.ES365.ShopApp.Controllers
{
    public class AdminPortalController : BaseController
    {
        private readonly List<SelectListItem> _categoriesList;

        private readonly ICategoryRepository _categoryRepository;

        private readonly IProductRepository _productRepository;

        private ProductViewModel _productViewModel;

        public AdminPortalController(ICategoryRepository categoryRepository, IProductRepository productRepository) 
            : base(categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;

            _categoriesList = new List<SelectListItem>();
        }

        [HttpGet]
        public ActionResult CreateNewProduct()
        {

            CreateSelectedItemListForCategories();

            return View(_productViewModel);
        }

        [HttpPost]
        public ActionResult CreateNewProduct(ProductViewModel productviewmodel)
        {
            var model = productviewmodel;

            var isProductOnSale = Request["IsOnSale"];

            if (isProductOnSale != null && isProductOnSale.Equals("on"))
            {
                productviewmodel.Product.IsOnSale = true;
            }
           
            if (ModelState.IsValid && !productviewmodel.Product.CategoryId.Equals(Guid.Empty))
            {
                _productRepository.AddProduct(productviewmodel.Product);
                return RedirectToAction("AllProducts", "Shop");
            }

            ModelState.AddModelError("Invalid data", "Please ensure all your field are valid");
            CreateSelectedItemListForCategories();
            productviewmodel.Categories = _categoriesList;
            return View(productviewmodel);
        }


        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            TempData["CategoriesList"] = base.Categories;
        }

        private void CreateSelectedItemListForCategories()
        {
            //Default Item for dropdown list
            _categoriesList.Add(new SelectListItem
            {
                Text = "Select product Category",
                Value = Guid.Empty.ToString(),
                Selected = true
            });

            var allCategories = _categoryRepository.GetAllCategories();

            _categoriesList.AddRange(allCategories.Select(category => new SelectListItem
            {
                Text = category.ShortName,
                Value = category.ID.ToString()
            }));

            _productViewModel = new ProductViewModel
            {
                Categories = _categoriesList
            };
        }
    }
}