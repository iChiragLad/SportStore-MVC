using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        IProductRepository _repository;
        public CartController(IProductRepository repository)
        {
            _repository = repository;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel {Cart = GetCart(), ReturnUrl = returnUrl });
        }

        public RedirectToRouteResult AddToCart(int ProductId, string returnUrl)
        {
            Product product = _repository.Products.FirstOrDefault(p => p.ProductId == ProductId);
            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int ProductId, string returnUrl)
        {
            Product product = _repository.Products.FirstOrDefault(p => p.ProductId == ProductId);
            if (product != null)
            {
                GetCart().RemoveItem(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["cart"];

            if (cart == null)
            {
                Session["cart"] = new Cart();
                return (Cart)Session["cart"];
            }
            return cart;
        }
    }
}