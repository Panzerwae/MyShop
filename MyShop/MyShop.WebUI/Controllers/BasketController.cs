using MyShop.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class BasketController : Controller
    {
        IBasketService basketService;
        public BasketController(IBasketService BasketService)
        {
            this.basketService = BasketService;
        }
        public ActionResult Index()
        {
            var model = this.basketService.GetBasketItems(this.HttpContext);
            return View(model);
        }

        public ActionResult AddToBasket(String id)
        {
            this.basketService.AddToBasket(this.HttpContext, id);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromBasket(String id)
        {
            this.basketService.RemoveFromBasket(this.HttpContext, id);
            return RedirectToAction("Index");
        }

        public PartialViewResult BasketSummary() 
        {
            var basketSummary = this.basketService.GetBasketSummary(this.HttpContext);

            return PartialView(basketSummary);
        }
    }
}