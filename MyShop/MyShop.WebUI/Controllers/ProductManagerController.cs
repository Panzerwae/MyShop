using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using MyShop.DataAccess.InMemory;

namespace MyShop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        InMemoryRepository<Product> context;
        InMemoryRepository<ProductCategory> productCategories;

        public ProductManagerController()
        {
            this.context = new InMemoryRepository<Product>();
            this.productCategories = new InMemoryRepository<ProductCategory>();
        }

        public ActionResult Index()
        {
            List<Product> products = this.context.Collection().ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            ProductManagerViewModel viewModel = new ProductManagerViewModel();

            viewModel.Product = new Product();
            viewModel.ProductCategories = productCategories.Collection();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                this.context.Insert(product);
                this.context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(String id) 
        {
            Product product = this.context.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductManagerViewModel viewModel = new ProductManagerViewModel();

                viewModel.Product = product;
                viewModel.ProductCategories = productCategories.Collection();

                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(Product product, String id) 
        {
            Product productToEdit = this.context.Find(id);

            if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid) 
                {
                    return View(product);
                }

                productToEdit.Category = product.Category;
                productToEdit.Description = product.Description;
                productToEdit.Image = product.Image;
                productToEdit.Name = product.Name;
                productToEdit.Price = product.Price;

                this.context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(String id)
        {
            Product product = this.context.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {

                return View(product);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(String id)
        {
            Product productToDelete = this.context.Find(id);

            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                this.context.Delete(id);
                this.context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}