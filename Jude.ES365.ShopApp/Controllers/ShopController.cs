using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Jude.ES365.ShopApp.BLogic.Interfaces;
using Jude.ES365.ShopApp.DatAcc.Models;

namespace Jude.ES365.ShopApp.Controllers
{
    public class ShopController : BaseController
    {
        private readonly IProductRepository _productRepository;


        private readonly ICategoryRepository _repository;

        private readonly IOrderRepository _orderRepository;

        private readonly ICustomerRepository _customerRepository;

       


        public ShopController(ICategoryRepository repository,
            IProductRepository productRepository,
            IOrderRepository orderRepository,
            ICustomerRepository customerRepository
            )
            : base(repository)
        {
            _repository = repository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllProducts()
        {
            var allProducts = _productRepository.GetAllProduct();
            return View(allProducts);
        }

        public ActionResult GetProductByCategory(Guid categoryid)
        {
            var categories = _productRepository.GetProductsByCategory(categoryid);

            return View(categories);
        }

        public ActionResult OnSale()
        {
            var productsOnSale = _productRepository.GetProductsOnSale();
            return View(productsOnSale);
        }

        public ActionResult ViewProduct(Guid productId)
        {
            var requestedProduct = _productRepository.GetProductById(productId);

            return View(requestedProduct);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            TempData["CategoriesList"] = Categories;
        }

        public ActionResult Checkout()
        {

            if (Session["ProductsCart"] != null && ((List<Guid>) Session["ProductsCart"]).Count > 0)
            {
                var productsInCustomerCart = ((List<Guid>) Session["ProductsCart"]);

                var confirmedOrder = _orderRepository.GenerateOrder(productsInCustomerCart);

                return View(confirmedOrder);
            }

            return View();

        }

        [HttpPost]
        public ActionResult Checkout(Order completecheckout)
        {
            var modelPosted = completecheckout;

            return View();
        }

        public bool AddToCart(Guid productid)
        {
            var isProductAddedToCart = false;

            var productInCurrentCarts = new List<Guid>();

            try
            {
                if (Session["ProductsCart"] != null)
                {
                    productInCurrentCarts = (List<Guid>) Session["ProductsCart"] ;

                    if (productid != Guid.Empty && productid !=null)
                    {
                        productInCurrentCarts.Add(productid);
                    }
                }
                else
                {
                    productInCurrentCarts.Add(productid);

                    Session["ProductsCart"] = productInCurrentCarts;
                }

                isProductAddedToCart = true;
            }
            catch (Exception exc)
            {
                isProductAddedToCart = false;
                Session["ProductsCart"] = null;
            }

            return isProductAddedToCart;
        }

       

        
    }
}